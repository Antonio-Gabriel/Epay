using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePay.Functions
{
    public static class MsShow
    {
        public static DialogResult ShowMessage(string message, string caption, MessageBoxButtons button, MessageBoxIcon icon)
        {
            DialogResult dlRegult = DialogResult.None;

            switch(button)
            {
                case MessageBoxButtons.OK:
                    using (MsgBoxOk ok = new MsgBoxOk())
                    {
                        ok.Message = message;
                        ok.lblTitle.Text = caption;
                        switch(icon)
                        {
                            case MessageBoxIcon.Information:
                                ok.IllustrationIcon = Properties.Resources.Graduation_cuate;
                                break; 
                            case MessageBoxIcon.Warning:
                                ok.IllustrationIcon = Properties.Resources.Warning_cuate1;
                                break;
                            case MessageBoxIcon.Error:
                                ok.IllustrationIcon = Properties.Resources._400_Error_Bad_Request_rafiki;
                                break;
                            case MessageBoxIcon.Question:
                                ok.IllustrationIcon = Properties.Resources.Questions_amico;
                                break;
                        }
                        dlRegult = ok.ShowDialog();
                    }
                    break;

                case MessageBoxButtons.YesNo:
                    using (MsgBox yesNo = new MsgBox())
                    {
                        yesNo.Message = message;
                        yesNo.lblTitle.Text = caption;
                        switch (icon)
                        {
                            case MessageBoxIcon.Information:
                                yesNo.IllustrationIcon = Properties.Resources.Graduation_cuate;
                                break;
                            case MessageBoxIcon.Warning:
                                yesNo.IllustrationIcon = Properties.Resources.Warning_cuate1;
                                break;
                            case MessageBoxIcon.Error:
                                yesNo.IllustrationIcon = Properties.Resources._400_Error_Bad_Request_rafiki;
                                break;
                            case MessageBoxIcon.Question:
                                yesNo.IllustrationIcon = Properties.Resources.Questions_amico;
                                break;
                        }
                        dlRegult = yesNo.ShowDialog();
                    }
                    break;
            }

            return dlRegult;
        }
    }
}
