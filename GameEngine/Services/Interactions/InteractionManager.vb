Public Class InteractionManager
    Public Property locationManager As LocationManager

    Public Sub New(locationManager As LocationManager)
        Me.locationManager = locationManager
    End Sub

    'list of managers
    Function checkEnter()

    End Function
    Function checkStand()

    End Function
    Function checkRemove(gameobj As GameObj, listoftypes As List(Of GameEnums.CharObjTypes))
        For Each type In listoftypes


            'type.onLeave(gameobj)
        Next
    End Function

    Function checkMove()

    End Function



End Class
