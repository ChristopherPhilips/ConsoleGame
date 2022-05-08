Imports Newtonsoft.Json

Public Class Frame 'renders a group of 4 (or less) maps into an array of char objs
    <JsonProperty("charmap")> Public Property charmap As List(Of String)
    <JsonProperty("colourmap")> Public Property colourmap As List(Of List(Of String))
    <JsonProperty("backgroundmap")> Public Property backgroundmap As List(Of List(Of String))
    <JsonProperty("typemap")> Public Property typemap As List(Of String)

    Public Property charObjArray As CharObj(,)
    Public Property Height
    Public Property Width
    Private ReadOnly Property nullChar As Char = "Q"c 'char in charmap that indicated gameobj DOES NOT occupy that tile
    Private ReadOnly Property invisChar As Char = "G"c 'Strings.ChrW(191) 'char in charmap that indicated gameobj DOES occupy that tile, but shouldn't be seen	

    Public Function render(parentGameObj As GameObj) As CharObj(,) 'turns 4 arrays into array of charobjs, called when we want the sprite

        'populate height+width from charmap
        Me.Height = charmap.Count - 1
        Me.Width = charmap(0).Length - 1 'gets column 2 of array 

        parentGameObj.occupying = New Boolean(Height, Width) {}


        Me.charObjArray = New CharObj(Me.Height, Me.Width) {}

        For i = 0 To Height
            For j = 0 To Width
                If charmap(i)(j) = nullChar Then Continue For 'skips making char obj for " " in char map
                Dim character As Char = charmap(i)(j) 'given char for the space

                Dim charBuilder As System.Text.StringBuilder = New System.Text.StringBuilder(character)

                If colourmap IsNot Nothing Then 'colour, default behavior is to do nothing
                    charBuilder.Insert(0, $"[{colourmap(i)(j)}]")
                    charBuilder.Append("[/]")
                End If
                If backgroundmap IsNot Nothing Then 'background, default behavior is to do nothing
                    charBuilder.Insert(0, $"[{backgroundmap(i)(j)}]")
                    charBuilder.Append("[/]")
                End If
                If typemap IsNot Nothing Then 'type default behavior is to display as just chars, if we're given a type map we will make special charobjs
                    Me.charObjArray(i, j) = New CharObj(charBuilder.ToString, parentGameObj.priority, parentGameObj, typemap(i)(j))
                    parentGameObj.occupying(i, j) = True

                    If charmap(i)(j) = invisChar Then 'check to lower prio on Charobjects we dont wanna see
                        Me.charObjArray(i, j).priority = -69
                    End If
                Else
                    Me.charObjArray(i, j) = New CharObj(charBuilder.ToString, parentGameObj.priority, parentGameObj) 'this gives ¿ in charmap -priority, so it can be in a square but not visible
                    parentGameObj.occupying(i, j) = True

                    If Me.charObjArray(i, j).CharObjType = invisChar Then
                        Me.charObjArray(i, j).priority = -69
                    End If
                End If

            Next
        Next

        Return Me.charObjArray
    End Function

End Class