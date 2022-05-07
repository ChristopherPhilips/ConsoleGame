Imports GameEngine

Public Class CrewmateManager
    Implements ICharObjManager

    Public Sub onEnter(otherCharObj As CharObj) Implements ICharObjManager.onEnter
    End Sub

    Public Sub onStand(otherCharObj As CharObj) Implements ICharObjManager.onStand
    End Sub

    Public Sub onLeave(otherCharObj As CharObj) Implements ICharObjManager.onLeave
    End Sub

    Public Sub Entering(otherCharObj As CharObj) Implements ICharObjManager.Entering
    End Sub

    Public Sub Leaving(otherCharObj As CharObj) Implements ICharObjManager.Leaving

    End Sub

    Public Sub onAttemptedEnter(otherCharObj As CharObj) Implements ICharObjManager.onAttemptedEnter

    End Sub

    Public Sub onAttemptedStand(otherCharObj As CharObj) Implements ICharObjManager.onAttemptedStand

    End Sub

    Public Sub onAttemptedLeave(otherCharObj As CharObj) Implements ICharObjManager.onAttemptedLeave

    End Sub

    Public Function doIcollide() As List(Of Char) Implements ICharObjManager.doIcollide
        Dim collideList As List(Of Char) = New List(Of Char) From {
            "C"c  'crewmate
        }
        Return collideList
    End Function
End Class
