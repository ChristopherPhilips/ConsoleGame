Imports GameEngine

Public Class CrewmateManager
    Implements ICharObjManager

    Public Sub onEnter() Implements ICharObjManager.onEnter
    End Sub

    Public Sub onStand() Implements ICharObjManager.onStand
    End Sub

    Public Sub onLeave() Implements ICharObjManager.onLeave
    End Sub

    Public Function doIcollide() As List(Of Char) Implements ICharObjManager.doIcollide
        Dim collideList As List(Of Char) = New List(Of Char) From {
            "C"c  'crewmate
        }
        Return collideList
    End Function
End Class
