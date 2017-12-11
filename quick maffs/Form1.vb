﻿Imports System
Imports System.IO

Public Class frmQM
    'initialiser les variables globales
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
        'la première question est toujours 1 / 1, donc mettre les nombres à 1 et 1
        Dim intNomGauche As Integer = 1
        Dim intNomDroit As Integer = 1

        'calculer la réponse
        Return calculerRéponse(intNomGauche, intNomDroit)
    End Function

    Private Function calculerRéponse(ByVal intNomGauche, ByVal intNomDroit)
        'retourner le reste de la division entre les deux nombres
        Return (intNomGauche Mod intNomDroit)
    End Function

    Private Sub btnSoumettre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoumettre.Click
        Dim intRéponseDonné As Integer
        Try
            'trouver le nombre donné par l'utilisateur
            intRéponseDonné = Val(txtReste.Text)

            'supprimer le texte dans la boite de texte de réponse
            txtReste.Select()
            txtReste.Clear()

            'agrandir les deux arrays pour être capable de tenir tous les entrées
            ReDim Preserve intBonneRéponse(intNomQuestion - 1)
            ReDim Preserve intRéponsesDonnées(intNomQuestion - 1)

            'assigner les bonnes valeurs aux bons index dans les arrays
            intBonneRéponse(intNomQuestion - 1) = intRéponse
            intRéponsesDonnées(intNomQuestion - 1) = intRéponseDonné

            'redimensionner le array 2D pour être capable de contenir toute l'information
            ReDim intDonnées(intNomQuestion - 1, 1)

            'combiner les deux arrays 1D en array 2D
            For Each intItem As Integer In intBonneRéponse
                intDonnées(Array.IndexOf(intBonneRéponse, intItem), 0) = intItem
                intDonnées(Array.IndexOf(intBonneRéponse, intItem), 1) = intRéponsesDonnées(Array.IndexOf(intBonneRéponse, intItem))
            Next

            If intRéponseDonné = intRéponse Then
                'si l'utilisateur donne la bonne réponse, lui dire
                MsgBox("Bonne réponse")
            Else
                'si l'utilisateur donne la mauvaise réponse, lui dire
                MsgBox("Mauvaise réponse")

                'processus "Game Over"

                'trouver l'endroit où l'utilisateur veut placer le fichier
                Dim nomFichier As String = chercherDossier() & "\résultats.txt"

                'si l'utilisateur a choisi un endroit de sauvegarde, sauvegarder le fichier. Si non, ne pas le sauvegarder.
                If nomFichier.Length > 0 Then
                    écriture("", nomFichier, False)

                    Dim bonnesRéponsesString As String = String.Join(",", intBonneRéponse)
                    Dim donnéesRéponsesString As String = String.Join(",", intRéponsesDonnées)

                    écriture(bonnesRéponsesString, nomFichier, True)
                    écriture(donnéesRéponsesString, nomFichier, True)
                End If

                'recommencer l'application
                Application.Restart()
            End If

            'incrémenter le nombre de la question
            intNomQuestion = intNomQuestion + 1

            'chercher une nouvelle question
            nouvelleQuestion()
        Catch
            'Si l'opération échoue, le nombre est trop gros
            MsgBox("Nombre trop gros")
        End Try
    End Sub

    Private Function chercherDossier()
        'demander à l'utilisateur où sauvegarder leurs données
        Dim dialogue As New FolderBrowserDialog()
        dialogue.SelectedPath = "C:\"
        dialogue.Description = "Choisir un dossier"
        Dim path As String
        If dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then
            path = dialogue.SelectedPath
        Else
            path = ""
        End If

        'retourner le path du dossier choisi
        Return path
    End Function

    Public Sub écriture(ByVal liste As String, ByVal nomFichier As String, ByVal append As Boolean)
        Dim strLecture As String
        If append = True And File.Exists(nomFichier) Then
            strLecture = My.Computer.FileSystem.ReadAllText(nomFichier)
        Else
            strLecture = ""
        End If

        If File.Exists(nomFichier) Then
            Dim sw As New StreamWriter(nomFichier)

            If liste.Length > 0 Then
                sw.WriteLine(strLecture + liste)
            Else
                sw.Close()
                File.Delete(nomFichier)
            End If

            sw.Close()
        End If
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

    Private Sub txtReste_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReste.TextChanged
        Dim nombres = "0123456789"

        Dim texte As String = txtReste.Text
        Dim nombre As String
        Dim indexDeSelection As Integer = txtReste.SelectionStart
        Dim changer As Integer

        For x As Integer = 0 To txtReste.Text.Length - 1
            nombre = txtReste.Text.Substring(x, 1)
            If nombres.Contains(nombre) = False Then
                texte = texte.Replace(nombre, String.Empty)
                changer = 1
            End If
        Next

        txtReste.Text = texte
        txtReste.Select(indexDeSelection - changer, 0)
    End Sub
End Class
