﻿Imports System
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

        txtReste.Select()
        txtReste.Clear()

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

            Dim nomFichier As String = Application.StartupPath & "\myarray.txt"

            écriture("", nomFichier, False)

            Dim bonnesRéponsesString As String = String.Join(",", intBonneRéponse)
            Dim donnéesRéponsesString As String = String.Join(",", intRéponsesDonnées)

            écriture(bonnesRéponsesString, nomFichier, True)
            écriture(donnéesRéponsesString, nomFichier, True)

            Application.Restart()
        End If

        'incrémenter le nombre de la question
        intNomQuestion = intNomQuestion + 1

        'chercher une nouvelle question
        nouvelleQuestion()
    End Sub

    Public Sub écriture(ByVal liste As String, ByVal nomFichier As String, ByVal append As Boolean)
        Dim strLecture As String
        If append = True And File.Exists(nomFichier) Then
            strLecture = My.Computer.FileSystem.ReadAllText(nomFichier)
        Else
            strLecture = ""
        End If

        Dim sw As New StreamWriter(nomFichier)

        If liste.Length > 0 Then
            sw.WriteLine(strLecture + liste)
        Else
            sw.Close()
            File.Delete(nomFichier)
        End If

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
