Public Class frmQM

    Dim intNumQuestion As Integer
    Dim intRéponse As Integer
    Dim intDonnées(0, 0) As Integer
    Dim intBonneRéponse() As Integer
    Dim intRéponsesDonnées() As Integer

    Private Sub frmQM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'commencer avec la première question
        intNumQuestion = 1
        Dim premièreRéponse As Integer = premièreQuestion()
        intRéponse = premièreRéponse
    End Sub

    Private Function premièreQuestion()
        Dim numGauche As Integer = 1
        Dim numDroit As Integer = 1

        'calculer la réponse
        Return calculerRéponse(numGauche, numDroit)
    End Function

    Private Function calculerRéponse(ByVal numGauche, ByVal numDroit)
        Return (numGauche Mod numDroit)
    End Function

    Private Sub btnSoumettre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoumettre.Click
        Dim réponseDonné As Integer = Val(txtReste.Text)

        If réponseDonné = intRéponse Then
            MsgBox("Bonne réponse")
        Else
            MsgBox("Mauvaise réponse")
        End If

        ReDim Preserve intBonneRéponse(intNumQuestion - 1)
        ReDim Preserve intRéponsesDonnées(intNumQuestion - 1)
        intBonneRéponse(intNumQuestion - 1) = intRéponse
        intRéponsesDonnées(intNumQuestion - 1) = réponseDonné

        ReDim intDonnées(intNumQuestion - 1, 1)
        For Each item As Integer In intBonneRéponse
            intDonnées(Array.IndexOf(intBonneRéponse, item), 0) = item
            intDonnées(Array.IndexOf(intBonneRéponse, item), 1) = intRéponsesDonnées(Array.IndexOf(intBonneRéponse, item))
        Next

        'incrémenter le nombre de la question
        intNumQuestion = intNumQuestion + 1

        'chercher une nouvelle question
        nouvelleQuestion()
    End Sub

    Private Sub nouvelleQuestion()
        Dim numDroit As Integer = auHazard()
        Dim numGauche As Integer = auHazard() + numDroit

        intRéponse = calculerRéponse(numGauche, numDroit)

        lblNombreGauche.Text = numGauche
        lblNombreDroit.Text = numDroit
    End Sub

    Private Function auHazard()
        Randomize()

        Dim nombre As Integer = CInt(Math.Floor((intNumQuestion * 2) * Rnd())) + 1
        Return nombre
    End Function
End Class
