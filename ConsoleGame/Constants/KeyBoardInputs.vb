Public Class keyboardinputs

    Public Shared Sub ReadInput()

        While True

            Dim Keyinfo As ConsoleKeyInfo = Console.ReadKey(True)

            Select Case Keyinfo.Key
                Case ConsoleKey.UpArrow
                    Program.KeyboardActions.Enqueue(GameEnums.KeyboardActions.UpArrow)

                Case ConsoleKey.DownArrow
                    Program.KeyboardActions.Enqueue(GameEnums.KeyboardActions.DownArrow)

                Case ConsoleKey.LeftArrow
                    Program.KeyboardActions.Enqueue(GameEnums.KeyboardActions.LeftArrow)

                Case ConsoleKey.RightArrow
                    Program.KeyboardActions.Enqueue(GameEnums.KeyboardActions.RightArrow)

            End Select

        End While

    End Sub

End Class