Imports GameEngine
Public Class CenteredMenu 'creates items, 
    Inherits GameObj
    Implements KeyboardActionMethods

    Public Property currentSelected As MenuObject
    Public Property myButtons As List(Of MenuObject)

    Public Sub New(priority As Integer, location As (Integer, Integer), WidthHeight As (Integer, Integer), buttons As List(Of MenuObject))
        MyBase.New(priority, location, "none")
        Me.Height = WidthHeight.Item2 - 1
        Me.Width = WidthHeight.Item1 - 1
        Me.myButtons = buttons
        Me.spriteMap = New CharObj(Height, Width) {}
        Me.occupying = New Boolean(Height, Width) {}
        addremoveupdateButtons()
    End Sub

    Public Sub addremoveupdateButtons(Optional changingbutton As MenuObject = Nothing)
        If changingbutton IsNot Nothing Then
            If myButtons.Contains(changingbutton) Then
                myButtons.Remove(changingbutton)
            Else
                myButtons.Add(changingbutton)
            End If
        End If

        Dim totalButtonheight As Integer = 1

        For i = 0 To Me.myButtons.Count - 1 Step 1

            Dim button = Me.myButtons(i)
            If Me.currentSelected Is Nothing And button.isSelectable Then
                Me.currentSelected = button
                currentSelected.toggleSelected(True)
            End If

            button.parentMenu = Me

            Dim topleftXforButton As Integer = (Me.Width - button.Width) / 2 '(menu full length - button full length)/2
            Dim topleftYforButton As Integer = totalButtonheight '+height of all buttons before
            For rowNUM = 0 To button.Height Step 1
                For colNUM = 0 To button.Width Step 1 'for each spot in the button
                    If button.spriteMap(rowNUM, colNUM) IsNot Nothing Then
                        Me.spriteMap(totalButtonheight + rowNUM, topleftXforButton + colNUM) = button.spriteMap(rowNUM, colNUM)
                        Me.spriteMap(totalButtonheight + rowNUM, topleftXforButton + colNUM).parentGameObj = Me
                        Me.occupying(totalButtonheight + rowNUM, topleftXforButton + colNUM) = True
                    End If
                Next colNUM
            Next rowNUM
            totalButtonheight += button.Height + 1

        Next i

    End Sub
    Public Sub KeyboardAction(keyboardaction As GameEnums.KeyboardActions) Implements KeyboardActionMethods.KeyboardAction
        Select Case keyboardaction


            Case GameEnums.KeyboardActions.DownArrow

                Dim indexofCurrent = Me.myButtons.IndexOf(Me.currentSelected)
                If Me.myButtons.Count > indexofCurrent + 1 AndAlso Me.myButtons(indexofCurrent + 1).isSelectable Then

                    Me.currentSelected = Me.myButtons(indexofCurrent)
                    Me.currentSelected.toggleSelected(False)

                    Me.myButtons(indexofCurrent + 1).toggleSelected(True)
                    Me.currentSelected = Me.myButtons(indexofCurrent + 1)

                    Me.didChange = True
                    Me.animationChange = True
                    addremoveupdateButtons()
                End If


            Case GameEnums.KeyboardActions.UpArrow

                Dim indexofCurrent = Me.myButtons.IndexOf(Me.currentSelected)
                If Me.myButtons.Count - indexofCurrent < indexofCurrent AndAlso Me.myButtons(indexofCurrent).isSelectable Then

                    Me.currentSelected = Me.myButtons(indexofCurrent)
                    Me.currentSelected.toggleSelected(False)

                    Me.myButtons(indexofCurrent - 1).toggleSelected(True)
                    Me.currentSelected = Me.myButtons(indexofCurrent - 1)

                    Me.didChange = True
                    Me.animationChange = True
                    addremoveupdateButtons()
                End If

            Case GameEnums.KeyboardActions.SpaceBar

                currentSelected.onSelect()

        End Select

    End Sub
End Class
