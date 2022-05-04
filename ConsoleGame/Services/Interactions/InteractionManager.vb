Public Class InteractionManager
    Public Property locationManager As LocationManager

    Public Sub New(locationManager As LocationManager)
        Me.locationManager = locationManager
    End Sub

    'list of managers

    Function checkRemove(gameobj As GameObj, listoftypes As List(Of GameEnums.CharObjTypes))

        For Each type In listoftypes


            'type.onLeave(gameobj)
        Next

    End Function


End Class
