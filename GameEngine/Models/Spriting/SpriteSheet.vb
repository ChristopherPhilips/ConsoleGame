Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Public Class SpriteSheet
    <JsonProperty("spritesheet")>
    Public Property SpriteSheet As Animations


    Public Function getFrame(animationName As String, framenumber As Integer, parentGameObj As GameObj) As CharObj(,)
        'todo: add logic to loop animation
        If animationName = "init" Then
            Return SpriteSheet.initFrame.render(parentGameObj)
        End If





        Dim frame As CharObj(,) = SpriteSheet.animations(animationName)(framenumber).render(parentGameObj)



        Return frame
    End Function
End Class



