Public Class InputManager


    Public Shared KeyboardActions As Queue(Of GameEnums.KeyboardActions) = New Queue(Of GameEnums.KeyboardActions)

    Public Shared Sub ReadInput()

        While True
            Dim Keyinfo As ConsoleKeyInfo = Console.ReadKey(True)
            Select Case Keyinfo.Key

                Case ConsoleKey.UpArrow
                    KeyboardActions.Enqueue(GameEnums.KeyboardActions.UpArrow)
                Case ConsoleKey.DownArrow
                    KeyboardActions.Enqueue(GameEnums.KeyboardActions.DownArrow)
                Case ConsoleKey.LeftArrow
                    KeyboardActions.Enqueue(GameEnums.KeyboardActions.LeftArrow)
                Case ConsoleKey.RightArrow
                    KeyboardActions.Enqueue(GameEnums.KeyboardActions.RightArrow)

                Case ConsoleKey.W
                    KeyboardActions.Enqueue(GameEnums.KeyboardActions.W)
                Case ConsoleKey.A
                    KeyboardActions.Enqueue(GameEnums.KeyboardActions.A)
                Case ConsoleKey.S
                    KeyboardActions.Enqueue(GameEnums.KeyboardActions.S)
                Case ConsoleKey.D
                    KeyboardActions.Enqueue(GameEnums.KeyboardActions.D)

            End Select
        End While

    End Sub

End Class
