Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Public Class SpriteSheet
    <JsonProperty("spritesheet")>
    Public Property SpriteSheet As Dictionary(Of String, List(Of Frame))
    Private Property PriorAnimation As String
    Private Property PriorFrame As Integer

    Public Function getFrame(animationName As String, parentGameObj As GameObj) As CharObj(,)


        If animationName = "init" Then 'gameobj init sprite
            Return SpriteSheet("idle")(0).render(parentGameObj)
        End If

        If PriorAnimation <> animationName Then 'start a different animation
            PriorAnimation = animationName
            PriorFrame = 0
            Return SpriteSheet(animationName)(0).render(parentGameObj)
        End If

        If PriorFrame + 1 > SpriteSheet(animationName).Count Then 'restart animation
            PriorFrame = 0
            Return SpriteSheet(animationName)(0).render(parentGameObj)
        End If

        PriorFrame += 1 'send back next frame in animation
        Return SpriteSheet(animationName)(PriorFrame).render(parentGameObj)




    End Function
End Class



