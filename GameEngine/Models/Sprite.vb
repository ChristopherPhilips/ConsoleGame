Public Class Sprite 'takes care of putting CharObjs together
    'properties
    Public Property Height As Integer
    Public Property Width As Integer
    Private Property charMap As List(Of String)    'character map, determines size
    Private Property colourMap As List(Of String)    'colour map
    Private Property backgroundMap As List(Of String)    'background colour map
    Private Property typeMap As List(Of String)    'type of charobj map
    '   Private Property spriteJSON???
    Private Property charObjArray As CharObj(,)   'charObjArray

    Public Sub New(spriteFileName As String) 'should be proper method
        'reads file, make the charObjArray

        'readFile()

        'populate height+width from charmap

        'initCharObjArray

        'render()

    End Sub

    ' ||      ||
    ' \/ temp \/
    Public Sub New(charMap As List(Of String), colourMap As List(Of String), backgroundMap As List(Of String), typeMap As List(Of String))
        Me.charMap = charMap
        Me.colourMap = colourMap
        Me.backgroundMap = backgroundMap
        Me.typeMap = typeMap

        initCharObjArray()
    End Sub

    'methods
    Private Sub initCharObjArray() 'makes initCharObjArray
        Me.charObjArray = New CharObj(charMap.Count - 1, charMap(0).Length - 1) {}
    End Sub
    Private Sub readFile()
        'read text file
        'create 4 list(ofString)
    End Sub
    Private Sub render()
        'turn 4 maps into correct char objs


        'typemap
        'tell the interaction manager what type came outa the sprite

        'put into grid
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
