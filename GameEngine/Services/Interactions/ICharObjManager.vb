Public Class ICharObjManager

    Public Property doIcollide As List(Of Char) = New List(Of Char) From {} 'who i collide with

    Public Sub New()
        Dim string3 = "sda"
    End Sub
    Public Overridable Sub onEnter(otherCharObj As CharObj) 'when i enter 
    End Sub
    Public Overridable Sub onStand(otherCharObj As CharObj) 'when i end turn here
    End Sub
    Public Overridable Sub onLeave(otherCharObj As CharObj) 'when i leave 
    End Sub


    Public Overridable Sub EnteringMe(otherCharObj As CharObj) 'when someone else actually enters
    End Sub
    Public Overridable Sub LeavingMe(otherCharObj As CharObj) 'when someone else actually leaves
    End Sub


    Public Overridable Sub onAttemptedEnter(otherCharObj As CharObj) 'when somone else trys to enter my tile 
    End Sub
    Public Overridable Sub onAttemptedStand(otherCharObj As CharObj) 'when someone else trys to ends turn on my tile (while being there last frame)
    End Sub
    Public Overridable Sub onAttemptedLeave(otherCharObj As CharObj) 'when someone else trys to leaves my tile 
    End Sub


End Class
