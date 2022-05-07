Imports GameEngine

Public Class CrewmateManager
    Implements ICharObjManager



    Public Sub onEnter(otherCharObjType As Char) Implements ICharObjManager.onEnter
    End Sub


    Public Sub onStand(otherCharObjType As Char) Implements ICharObjManager.onStand
    End Sub


    Public Sub onLeave(otherCharObjType As Char) Implements ICharObjManager.onLeave
    End Sub


    Sub onAttemptedEnter(otherCharObjType As Char) Implements ICharObjManager.onAttemptedEnter
    End Sub


    Sub onAttemptedStand(otherCharObjType As Char) Implements ICharObjManager.onAttemptedStand 'when someone else ends turn on my tile
    End Sub


    Sub onAttemptedLeave(otherCharObjType As Char) Implements ICharObjManager.onAttemptedLeave
    End Sub


    Public Function doIcollide() As List(Of Char) Implements ICharObjManager.doIcollide
        Dim collideList As List(Of Char) = New List(Of Char) From {
            "C"c  'crewmate
        }
        Return collideList
    End Function
End Class
