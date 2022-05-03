Public Class LocationManager
    Private Property locationObjAry As LocationObj(,) = New LocationObj(2, 2) {}

    Private Height As Integer
    Private Width As Integer


    'Me.RemoveGameObj(gameobject)



    Public Sub New(height As Integer, width As Integer)
        Me.Height = height
        Me.Width = width

        Me.locationObjAry = New LocationObj(height - 1, width - 1) {}

        InitlocationObjAry()
    End Sub
    Public Sub AddCharObj(charobj As CharObj, coordx As Integer, coordy As Integer) 'puts charobjs into locationobjs
        'askInteractionManager()
        Me.locationObjAry(coordx, coordy).addChar(charobj)
    End Sub

    Public Sub RemoveChar(parentGameObj As GameObj, coordx As Integer, coordy As Integer)
        'askInteractionManager()
        Me.locationObjAry(coordx, coordy).removeChar(parentGameObj)
    End Sub
    Private Sub InitlocationObjAry() 'used to fill the locationObjAry with locationobj

        'should iterate over the rows
        For i = 0 To Height - 1 Step 1
            'should put locationobjs in the row
            For j = 0 To Width - 1 Step 1
                Me.locationObjAry(i, j) = New LocationObj((i, j))
            Next j
        Next i

    End Sub
    Public Function RenderScreen() As List(Of String) 'goes through location objs and grabs their highest prio char

        Dim array As LocationObj(,) = Me.locationObjAry
        Dim renderedscreen As List(Of String) = New List(Of String)

        'should iterate over the 60 rows
        For i = 0 To array.GetUpperBound(0) Step 1
            Dim currow As String = ""
            'should iterate over the 140 locationobjs in the row
            For j = 0 To array.GetUpperBound(1) Step 1
                currow += (array(i, j).toPrint)
            Next j
            renderedscreen.Add(currow)
        Next i
        Return renderedscreen

    End Function
End Class
