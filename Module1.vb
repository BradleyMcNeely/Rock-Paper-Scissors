Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Security.Authentication
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.VisualBasic.Devices
Imports Microsoft.Win32

Module Module1
    Dim usermoves(4), computermoves(4) As Integer
    Dim outcomes(4) As String
    Dim num As Integer
    Dim rand As New Random
    Dim winP, lossP, tieP As Double
    Dim win, loss, tie As Integer



    Sub Main()


        PrintTitle()
        For i As Integer = 0 To 4
            usermoves(i) = getvalidinput()
            computermoves(i) = ComputerMove()
            Console.WriteLine($"You played {convertnumtoword(usermoves(i))} the computer played {convertnumtoword(computermoves(i))}")
            outcomes(i) = DetermineOutcome(usermoves(i), computermoves(i))
            Console.WriteLine($"You {outcomes(i)}")
        Next
        printreport()
        Console.ReadKey()
    End Sub
    Sub PrintTitle()

        Console.Write(".-. .-. .-. . .     .-. .-. .-. .-. .-.     .-. .-. .-. .-. .-. .-. .-. .-.
|(  | | |   |<      |-' |-| |-' |-  |(      `-. |    |  `-. `-. | | |(  `-.
' ' `-' `-' ' ` ,   '   ` ' '   `-' ' ' ,   `-' `-' `-' `-' `-' `-' ' ' `-'
    _______             _______                      ________
---'   ____)        ---'   ____)____             ---'    ____)____
      (_____)                 ______)                       ______)
      (_____)                 _______)                   __________)
      (____)                 _______)                   (____)
---.__(___)         ---.__________)              ---.__(___)
")

    End Sub
    Sub printreportline(round, userplay, compplay, outcome)
        Console.WriteLine("| {0} | {1} | {2} | {3} |", round.ToString.PadRight(11), userplay.ToString.PadRight(10), compplay.ToString.PadRight(10), outcome.ToString.PadRight(12))



    End Sub
    Function getvalidinput()
        Dim num As Integer
        Dim input As String
        Dim valid As Boolean = False
        Do
            Console.Write("enter 1 for rock, 2 for paper or 3 for scissors -> ")
            input = Console.ReadLine
            Integer.TryParse(input, num)
            If num <> 1 AndAlso num <> 2 AndAlso num <> 3 Then
                valid = False
                Console.WriteLine("Invalid Input")
            Else
                valid = True
            End If
        Loop While Not valid

        Return num
    End Function
    Sub printreport()
        Console.WriteLine("".PadRight(55, "#"))
        Console.WriteLine("############ Rock, Paper, Scissors Report #############")
        Console.WriteLine("".PadRight(55, "#"))
        Console.WriteLine("".PadRight(55, "-"))
        Console.WriteLine("|" & "Round Number ".PadRight(7) & "| " & "User Played".PadRight(7) & "| " & "Computer Played".PadRight(7) & "| " & "Outcome".PadRight(7))
        Console.WriteLine("".PadRight(55, "-"))
        For I As Integer = 0 To 4
            printreportline(I + 1, usermoves(I), computermoves(I), outcomes(I))
            Console.WriteLine("".PadRight(55, "-"))

        Next
        Console.WriteLine($"you won {win} of the matches")
        Console.WriteLine($"you lossed {loss} of the matches")
        Console.WriteLine($"you tied {tie} of the times")


    End Sub

    Sub calcPercent()
        winP = win / 5
        lossP = loss / 5
        tieP = tie / 5
    End Sub

    Function ComputerMove()
        Dim guess As Integer = rand.Next(1, 4)
        Return guess
    End Function
    Function convertnumtoword(num As Integer) As String
        Dim word As String = "undefined"
        If num = 1 Then
            word = "Rock"
        ElseIf num = 2 Then
            word = "Paper"
        ElseIf num = 3 Then
            word = "Scissors"
        End If
        Return word
    End Function
    Function DetermineOutcome(userplay As Integer, compplay As Integer) As String
        Dim outcome As String
        If (userplay = 1 AndAlso compplay = 3) OrElse
                (userplay = 2 AndAlso compplay = 1) OrElse
                (userplay = 3 AndAlso compplay = 2) Then
            outcome = "Won"
            win += 1
        ElseIf (compplay = 1 AndAlso userplay = 3) OrElse
                (compplay = 2 AndAlso userplay = 1) OrElse
                (compplay = 3 AndAlso userplay = 2) Then
            outcome = "Lost"
            loss += 1
        ElseIf userplay = compplay Then
            outcome = "Tied"
            tie += 1
        End If
        Return outcome
    End Function

End Module
