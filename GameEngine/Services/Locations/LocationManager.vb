Public Class LocationManager
    Private Property locationObjAry As LocationObj(,) = New LocationObj(2, 2) {}

    Private Height As Integer
    Private Width As Integer



    Public Sub New(height As Integer, width As Integer)
        Me.Height = height
        Me.Width = width

        initLocationObjAry()

    End Sub
    Public Sub AddCharObj(charobj As CharObj, coordx As Integer, coordy As Integer) 'puts charobjs into locationobjs
        Me.locationObjAry(coordx, coordy).addChar(charobj, charobj.priority)
    End Sub

    Public Sub RemoveChar(parentGameObj As GameObj, coordx As Integer, coordy As Integer)
        Me.locationObjAry(coordx, coordy).removeChar(parentGameObj)
    End Sub
    Private Sub initLocationObjAry() 'used to fill the locationObjAry with locationobj

        Me.locationObjAry = New LocationObj(Height - 1, Width - 1) {}

        'should iterate over the rows
        For i = 0 To Height - 1 Step 1
            'should put locationobjs in the row
            For j = 0 To Width - 1 Step 1
                Me.locationObjAry(i, j) = New LocationObj()
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

    Public Function getCharObjs(coordx As Integer, coordy As Integer, parentGameObj As GameObj) As List(Of CharObj)
        Return locationObjAry(coordx, coordy).getCharObjs(parentGameObj)
    End Function

End Class
