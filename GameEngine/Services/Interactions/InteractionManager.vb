Public Class InteractionManager
    Private Property locationManager As LocationManager

    Public Sub New(locationManager As LocationManager)
        Me.locationManager = locationManager
    End Sub

    Sub checkEnter(charobject As CharObj, listoftypes As List(Of CharObj))  'called when an object enters a tile

    End Sub

    Sub checkStand(charobject As CharObj, listoftypes As List(Of CharObj))  'called when an object ends a turn in a tiles they were already in

    End Sub

    Sub checkRemove(LeavingCharObj As CharObj, listofCharObj As List(Of CharObj)) 'called when an object leaves a tile
        Dim MyCharobjType = LeavingCharObj.CharObjType

        If Engine.CharacterManagers.ContainsKey(MyCharobjType) Then 'manager for the charobj leaving
            Dim MyManager As ICharObjManager = Engine.CharacterManagers(MyCharobjType)

            For Each charobj In listofCharObj
                Dim OtherCharobjType = LeavingCharObj.CharObjType

                If Engine.CharacterManagers.ContainsKey(charobj.CharObjType) Then 'manager for the charobj its leaving
                    Dim OtherManager As ICharObjManager = Engine.CharacterManagers(OtherCharobjType)
                    OtherManager.onAttemptedLeave(MyCharobjType)

                End If


                'if it has methods
                'call its onLeave method
                'type.onLeave(charobj in,)

                MyManager.onLeave(OtherCharobjType)

            Next

        End If


    End Sub
    Sub checkAttemptedEnter(offendingcharobject As CharObj, defendingCharObject As CharObj) 'calls when an object wants to move out of or into a tile (think bouncy walls, turn attempted movement into backwards movement)

    End Sub
    Sub checkAttemptedStand(offendingcharobject As CharObj, defendingCharObject As CharObj) 'calls when an object wants to end turn on a tile 

    End Sub
    Sub checkAttemptedLeave(offendingcharobject As CharObj, defendingCharObject As CharObj) 'calls when an object wants to move out of a tile (think sticky floor)

    End Sub

    Function checkMove(gameobject As GameObj, deltaxy As (Integer, Integer)) As Boolean
        Dim validMove As Boolean = True

        Dim topleftX = gameobject.location.Item1 + deltaxy.Item1
        Dim topleftY = gameobject.location.Item2 + deltaxy.Item2

        For i = 0 To gameobject.Height 'iterating over i
            For j = 0 To gameobject.Width
                If gameobject.occupying(i, j) Then 'check locationObj for each true in occupying

                    Dim charObjsAtLocation As List(Of CharObj) = Me.locationManager.getCharObjs(topleftX + i, topleftY + j, gameobject)

                    For Each charObj In charObjsAtLocation

                        Dim character As Char = charObj.CharObjType
                        If Engine.CharacterManagers.ContainsKey(character) Then 'if no manager assume no collision

                            Dim manager = Engine.CharacterManagers(character)
                            If manager.doIcollide().Contains(gameobject.spriteMap(i, j).CharObjType) Then
                                validMove = False 'if character in question collide, move is invalid!
                            Else

                                manager.onAttemptedEnter()
                        End If




                    Next
                End If
            Next
        Next

        Return validMove

    End Function



End Class
