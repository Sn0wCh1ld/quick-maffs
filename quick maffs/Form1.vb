Public Class frmQM

    Dim numQuestion As Integer
    Dim réponse As Integer
    Dim strDonnées(0, 0) As Integer
    Dim strBonneRéponse() As Integer
    Dim strRéponsesDonnées() As Integer

    Private Sub frmQM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'commencer avec la première question
        numQuestion = 1
        Dim premièreRéponse As Integer = premièreQuestion()
        réponse = premièreRéponse
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

        If réponseDonné = réponse Then
            MsgBox("Bonne réponse")
        Else
            MsgBox("Mauvaise réponse")
        End If

        ReDim Preserve strBonneRéponse(numQuestion - 1)
        ReDim Preserve strRéponsesDonnées(numQuestion - 1)
        strBonneRéponse(numQuestion - 1) = réponse
        strRéponsesDonnées(numQuestion - 1) = réponseDonné

        ReDim strDonnées(numQuestion - 1, 1)
        For Each item As Integer In strBonneRéponse
            strDonnées(Array.IndexOf(strBonneRéponse, item), 0) = item
            strDonnées(Array.IndexOf(strBonneRéponse, item), 1) = strRéponsesDonnées(Array.IndexOf(strBonneRéponse, item))
        Next

        'incrémenter le nombre de la question
        numQuestion = numQuestion + 1

        'chercher une nouvelle question
        nouvelleQuestion()
    End Sub

    Private Sub nouvelleQuestion()
        Dim numDroit As Integer = auHazard()
        Dim numGauche As Integer = auHazard() + numDroit

        réponse = calculerRéponse(numGauche, numDroit)

        lblNombreGauche.Text = numGauche
        lblNombreDroit.Text = numDroit
    End Sub

    Private Function auHazard()
        Randomize()

        Dim nombre As Integer = CInt(Math.Floor((numQuestion * 2) * Rnd())) + 1
        Return nombre
    End Function
End Class
