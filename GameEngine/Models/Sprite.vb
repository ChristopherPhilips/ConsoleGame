Imports Newtonsoft.Json.Linq
Public Class Sprite 'takes care of putting CharObjs together
    'properties
    Public Property Height As Integer
    Public Property Width As Integer
    Private Property charMap As List(Of String) = New List(Of String)   'character map, determines size
    Private Property colourMap As List(Of String) = New List(Of String)   'colour map
    Private Property backgroundMap As List(Of String) = New List(Of String)  'background colour map
    Private Property typeMap As List(Of String) = New List(Of String)   'type of charobj map
    '   Private Property spriteJSON???
    Private Property charObjArray As CharObj(,)   'charObjArray
    Private Property needDefaults As Boolean() = New Boolean(2) {True, True, True} 'stores needed default 0:Colour 1:Background 2:Type

    Public Sub New(spriteFileName As String, parentGameObj As GameObj) 'reads file, make the charObjArray
        'turns files into 4 lists
        readFile(spriteFileName)

        'populate height+width from charmap
        Me.Height = charMap.Count - 1
        Me.Width = charMap(0).Length - 1

        'sets size of charObjArray
        initCharObjArray()

        'creates charobjs and puts into array
        render(parentGameObj)

    End Sub

    'methods
    Private Sub initCharObjArray() 'makes initCharObjArray
        Me.charObjArray = New CharObj(Me.Height, Me.Width) {}
    End Sub
    Private Sub readFile(spriteFileName As String)

        Dim filereader2 = New System.IO.StreamReader(spriteFileName)
        Dim rawJSON = filereader2.ReadToEnd
        Dim parsedJson As JObject = JObject.Parse(rawJSON)

        Dim defaultColours As List(Of String) = New List(Of String)
        Dim defualtBackground As List(Of String) = New List(Of String)
        Dim defaultType As List(Of String) = New List(Of String)

        'turning JObjects into lists of string
        Dim charMapJOBJECT = parsedJson("init")("charmap")
        For Each row In charMapJOBJECT
            Me.charMap.Add(row)
        Next

        If parsedJson("init")("colourmap") IsNot Nothing Then
            Dim colourMapJOBJECT = parsedJson("init")("colourmap")
            For Each row In colourMapJOBJECT
                Me.colourMap.Add(row)
            Next
            Me.needDefaults(0) = False
        Else
            Me.needDefaults(0) = True
        End If

        If parsedJson("init")("backgroundmap") IsNot Nothing Then
            Dim backgroundMapJOBJECT = parsedJson("init")("backgroundmap")
            For Each row In backgroundMapJOBJECT
                Me.backgroundMap.Add(row)
            Next
            Me.needDefaults(1) = False
        Else
            Me.needDefaults(1) = True
        End If

        If parsedJson("init")("typemap") IsNot Nothing Then
            Dim typeMapJOBJECT = parsedJson("init")("typemap")
            For Each row In typeMapJOBJECT
                Me.typeMap.Add(row)
            Next
            Me.needDefaults(2) = False
        Else
            Me.needDefaults(2) = True
        End If








    End Sub
    Private Sub render(parentGameObj As GameObj)


        For i = 0 To Height
            For j = 0 To Width
                Dim character As Char = Me.charMap(i)(j)
                Dim charBuilder As System.Text.StringBuilder = New System.Text.StringBuilder(character)

                If needDefaults(0) = False Then 'colour, default behavior is to do nothing
                    charBuilder.Insert(0, $"[{colourMap(i)(j)}]")
                    charBuilder.Append("[/]")
                End If
                If needDefaults(1) = False Then 'background, default behavior is to do nothing
                    charBuilder.Insert(0, $"[{backgroundMap(i)(j)}]")
                    charBuilder.Append("[/]")
                End If

                If needDefaults(2) = False Then 'type default behavior is to display literal, if we're given a type map we will make special charobjs

                    'this if statement should make different types of char objects
                    If Me.typeMap(i)(j) = " "c Then ' spaceChar in typemap means object doesnt occupy that space at all

                    Else
                        Me.charObjArray(i, j) = New CharObj(charBuilder.ToString, parentGameObj)
                    End If

                Else
                    Me.charObjArray(i, j) = New CharObj(charBuilder.ToString, parentGameObj)
                End If

            Next
        Next
    End Sub
    'getRenderedSprite{returns charobjarray} 'This is essentially the object as a collection of its parts
    Public Function getSprite()
        Return charObjArray
    End Function

    Public Function update()
        'functionality to have animations?

        'change maps
        'render again

    End Function
End Class
