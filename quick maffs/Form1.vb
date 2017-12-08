Imports System
Imports System.IO

Public Class frmQM

    Dim intNomQuestion As Integer
    Dim intRéponse As Integer
    Dim intDonnées(0, 0) As Integer
    Dim intBonneRéponse() As Integer
    Dim intRéponsesDonnées() As Integer

    Private Sub frmQM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'commencer avec la première question
        intNomQuestion = 1
        Dim intPremièreRéponse As Integer = premièreQuestion()
        intRéponse = intPremièreRéponse
    End Sub

    Private Function premièreQuestion()
        Dim intNomGauche As Integer = 1
        Dim intNomDroit As Integer = 1

        'calculer la réponse
        Return calculerRéponse(intNomGauche, intNomDroit)
    End Function

    Private Function calculerRéponse(ByVal intNomGauche, ByVal intNomDroit)
        Return (intNomGauche Mod intNomDroit)
    End Function

    Private Sub btnSoumettre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoumettre.Click
        Dim intRéponseDonné As Integer = Val(txtReste.Text)

<<<<<<< HEAD
        txtReste.Select()
        txtReste.Clear()
=======

>>>>>>> 17544ad102c2971c2f7d88652b376e1155024376

        ReDim Preserve intBonneRéponse(intNomQuestion - 1)
        ReDim Preserve intRéponsesDonnées(intNomQuestion - 1)
        intBonneRéponse(intNomQuestion - 1) = intRéponse
        intRéponsesDonnées(intNomQuestion - 1) = intRéponseDonné

        ReDim intDonnées(intNomQuestion - 1, 1)
        For Each intItem As Integer In intBonneRéponse
            intDonnées(Array.IndexOf(intBonneRéponse, intItem), 0) = intItem
            intDonnées(Array.IndexOf(intBonneRéponse, intItem), 1) = intRéponsesDonnées(Array.IndexOf(intBonneRéponse, intItem))
        Next

        If intRéponseDonné = intRéponse Then
            MsgBox("Bonne réponse")
        Else
            MsgBox("Mauvaise réponse")

            Dim bonnesRéponsesString As String = String.Join(",", intBonneRéponse)
            Dim donnéesRéponsesString As String = String.Join(",", intRéponsesDonnées)

            Dim nomFichier As String = Application.StartupPath & "\myarray.txt"

            écriture(bonnesRéponsesString, nomFichier)
            écriture(donnéesRéponsesString, nomFichier)

            Application.Restart()
        End If

        'incrémenter le nombre de la question
        intNomQuestion = intNomQuestion + 1

        'chercher une nouvelle question
        nouvelleQuestion()
    End Sub

    Public Sub écriture(ByVal liste As String, ByVal nomFichier As String)
        Dim strLecture As String = My.Computer.FileSystem.ReadAllText(nomFichier)
        Dim sw As New StreamWriter(nomFichier)
        sw.WriteLine(strLecture + liste)
        sw.Close()
    End Sub

    Private Sub nouvelleQuestion()
        Dim intNomDroit As Integer = auHazard()
        Dim intNomGauche As Integer = auHazard() + intNomDroit

        intRéponse = calculerRéponse(intNomGauche, intNomDroit)

        lblNombreGauche.Text = intNomGauche
        lblNombreDroit.Text = intNomDroit
    End Sub

    Private Function auHazard()
        Randomize()

        Dim intNombre As Integer = CInt(Math.Floor((intNomQuestion * 2) * Rnd())) + 1
        Return intNombre
    End Function
End Class
