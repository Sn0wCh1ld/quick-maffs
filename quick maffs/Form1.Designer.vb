<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblNombreGauche = New System.Windows.Forms.Label()
        Me.lblNombreDroit = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtReste = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSoumettre = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblNombreGauche
        '
        Me.lblNombreGauche.Font = New System.Drawing.Font("Mistral", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreGauche.Location = New System.Drawing.Point(12, 9)
        Me.lblNombreGauche.Name = "lblNombreGauche"
        Me.lblNombreGauche.Size = New System.Drawing.Size(163, 113)
        Me.lblNombreGauche.TabIndex = 0
        Me.lblNombreGauche.Text = "1"
        Me.lblNombreGauche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombreDroit
        '
        Me.lblNombreDroit.Font = New System.Drawing.Font("Mistral", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreDroit.Location = New System.Drawing.Point(328, 9)
        Me.lblNombreDroit.Name = "lblNombreDroit"
        Me.lblNombreDroit.Size = New System.Drawing.Size(163, 113)
        Me.lblNombreDroit.TabIndex = 1
        Me.lblNombreDroit.Text = "1"
        Me.lblNombreDroit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Mistral", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(181, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 113)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "÷"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtReste
        '
        Me.txtReste.Location = New System.Drawing.Point(12, 225)
        Me.txtReste.Name = "txtReste"
        Me.txtReste.Size = New System.Drawing.Size(479, 20)
        Me.txtReste.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(25, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(466, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Reste:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSoumettre
        '
        Me.btnSoumettre.Location = New System.Drawing.Point(194, 145)
        Me.btnSoumettre.Name = "btnSoumettre"
        Me.btnSoumettre.Size = New System.Drawing.Size(128, 23)
        Me.btnSoumettre.TabIndex = 5
        Me.btnSoumettre.Text = "Button1"
        Me.btnSoumettre.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 261)
        Me.Controls.Add(Me.btnSoumettre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtReste)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNombreDroit)
        Me.Controls.Add(Me.lblNombreGauche)
        Me.MaximumSize = New System.Drawing.Size(519, 300)
        Me.MinimumSize = New System.Drawing.Size(519, 300)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombreGauche As System.Windows.Forms.Label
    Friend WithEvents lblNombreDroit As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtReste As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSoumettre As System.Windows.Forms.Button

End Class
