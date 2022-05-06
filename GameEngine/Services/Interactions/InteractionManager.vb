Public Class InteractionManager
    Public Property locationManager As LocationManager

    Public Sub New(locationManager As LocationManager)
        Me.locationManager = locationManager


    End Sub

    Sub checkEnter(charobject As CharObj, listoftypes As List(Of CharObj))


    End Sub

    Sub checkStand(charobject As CharObj, listoftypes As List(Of CharObj))

    End Sub

    Sub checkRemove(charobject As CharObj, listoftypes As List(Of Char))
        For Each type In listoftypes
            'if it has methods
            'call its onLeave method
            'type.onLeave(charobj in,)
            Dim manager = Engine.CharacterManagers(type)
            manager.onLeave()
        Next
    End Sub

    Function checkMove(gameobject As GameObj, deltaxy As (Integer, Integer)) As Boolean
        Dim validMove As Boolean = True

        Dim topleftX = gameobject.location.Item1 + deltaxy.Item1
        Dim topleftY = gameobject.location.Item2 + deltaxy.Item2

        For i = 0 To gameobject.Height
            For j = 0 To gameobject.Width
                If gameobject.occupying(i, j) Then 'check locationObj for each true in occupying

                    Dim charTypesAtLocation = Me.locationManager.getTypes(topleftX + i, topleftY + j, gameobject) 'todo: rewrite this string of getTypes methods to not need a parent gameobject

                    For Each character In charTypesAtLocation
                        If Engine.CharacterManagers.ContainsKey(character) Then 'if no manager assume no collision
                            Dim manager = Engine.CharacterManagers(character)
                            If manager.doIcollide().Contains(gameobject.spriteMap(i, j).CharObjType) Then
                                validMove = False 'if character in question collide, move is invalid!
                                Return validMove
                            Else
                                'if characters in question dont collide, move is valid
                            End If
                        Else
                            'if we dont find the charactermanager then move is valid ig
                        End If

                    Next

                Else
                    'if we dont occupy, move is valid

                End If
            Next
        Next

        Return validMove

    End Function



End Class
