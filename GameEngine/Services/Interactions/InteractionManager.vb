Public Class InteractionManager
    Private Property locationManager As LocationManager

    Public Sub New(locationManager As LocationManager)
        Me.locationManager = locationManager
    End Sub



    Sub checkEnter(EnteringCharObj As CharObj, coordx As Integer, coordy As Integer)  'called when an object enters a tile
        Dim MyCharobjType = EnteringCharObj.CharObjType
        Dim listofCharObj = Me.locationManager.getCharObjs(coordx, coordy, EnteringCharObj.parentGameObj)

        If Engine.CharacterManagers.ContainsKey(MyCharobjType) Then 'manager for the charobj leaving
            Dim MyManager As ICharObjManager = Engine.CharacterManagers(MyCharobjType)

            For Each charobj In listofCharObj
                Dim OtherCharobjType = charobj.CharObjType

                If Engine.CharacterManagers.ContainsKey(charobj.CharObjType) Then 'manager for the charobj its leaving
                    Dim OtherManager As ICharObjManager = Engine.CharacterManagers(OtherCharobjType)
                    OtherManager.EnteringMe(EnteringCharObj)

                End If

                MyManager.onEnter(charobj)

            Next

        End If
    End Sub

    Sub checkStand(gameobject As GameObj, location As (Integer, Integer))  'called when an object ends a turn in a tiles they were already in

        Dim topleftX = gameobject.location.Item1
        Dim topleftY = gameobject.location.Item2

        For i = 0 To gameobject.Height 'iterating over i
            For j = 0 To gameobject.Width
                If gameobject.occupying(i, j) Then 'check locationObj for each true in occupying
                    Dim charObjsAtCurrentLocation As List(Of CharObj) = Me.locationManager.getCharObjs(i, j, gameobject)
                    Dim MyCharobjType = gameobject.spriteMap(i, j).CharObjType

                    For Each charObj In charObjsAtCurrentLocation

                        Dim character As Char = charObj.CharObjType
                        If Engine.CharacterManagers.ContainsKey(character) Then 'if no manager assume no collision

                            Dim manager = Engine.CharacterManagers(character)
                            manager.onAttemptedStand(gameobject.spriteMap(i, j))

                        End If

                        If Engine.CharacterManagers.ContainsKey(MyCharobjType) Then 'if no manager assume no collision
                            Dim myManager = Engine.CharacterManagers(MyCharobjType)
                            myManager.onStand(charObj)
                        End If

                    Next
                End If
            Next
        Next

    End Sub

    Sub checkRemove(LeavingCharObj As CharObj, coordx As Integer, coordy As Integer) 'called when an object leaves a tile
        Dim MyCharobjType = LeavingCharObj.CharObjType
        Dim listofCharObj = Me.locationManager.getCharObjs(coordx, coordy, LeavingCharObj.parentGameObj)

        If Engine.CharacterManagers.ContainsKey(MyCharobjType) Then 'manager for the charobj leaving
            Dim MyManager As ICharObjManager = Engine.CharacterManagers(MyCharobjType)

            For Each charobj In listofCharObj
                Dim OtherCharobjType = LeavingCharObj.CharObjType

                If Engine.CharacterManagers.ContainsKey(charobj.CharObjType) Then 'manager for the charobj its leaving
                    Dim OtherManager As ICharObjManager = Engine.CharacterManagers(OtherCharobjType)
                    OtherManager.LeavingMe(LeavingCharObj)

                End If

                MyManager.onLeave(charobj)

            Next

        End If

    End Sub

    Function checkMove(gameobject As GameObj, deltaxy As (Integer, Integer)) As Boolean
        Dim validMove As Boolean = True

        Dim topleftX = gameobject.location.Item1 + deltaxy.Item1
        Dim topleftY = gameobject.location.Item2 + deltaxy.Item2

        For i = 0 To gameobject.Height 'iterating over i
            For j = 0 To gameobject.Width
                If gameobject.occupying(i, j) AndAlso locationManager.WithinBounds(topleftX + i, topleftY + j) Then  'check locationObj for each true in occupying

                    Dim charObjsAtNewLocation As List(Of CharObj) = Me.locationManager.getCharObjs(topleftX + i, topleftY + j, gameobject)
                    Dim charObjsAtCurrentLocation As List(Of CharObj) = Me.locationManager.getCharObjs(gameobject.location.Item1 + i, gameobject.location.Item2 + j, gameobject)

                    For Each charObj In charObjsAtNewLocation

                        Dim character As Char = charObj.CharObjType
                        If Engine.CharacterManagers.ContainsKey(character) Then 'if no manager assume no collision

                            Dim manager = Engine.CharacterManagers(character)
                            If manager.doIcollide.Contains(gameobject.spriteMap(i, j).CharObjType) Then
                                validMove = False 'if character in question collide, move is invalid!
                            End If

                            manager.onAttemptedEnter(gameobject.spriteMap(i, j))

                        End If
                    Next

                    For Each charObj In charObjsAtCurrentLocation

                        Dim character As Char = charObj.CharObjType
                        If Engine.CharacterManagers.ContainsKey(character) Then 'if no manager assume no collision

                            Dim manager = Engine.CharacterManagers(character)
                            manager.onAttemptedLeave(gameobject.spriteMap(i, j))

                        End If
                    Next
                End If
            Next
        Next

        Return validMove

    End Function



End Class
