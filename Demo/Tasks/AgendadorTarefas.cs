using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenNextOneDrive.Tasks
{
    public class AgendadorTarefas
    {
        public void AgendarTarefaPostgeSQL(string NomeTarefa, string PastaBkp, string CaminhoDump, string HoraBkp)
        {
            ExcluiTarefa(NomeTarefa);
            char quote = '"';
            string doubleQuotedPath = quote + PastaBkp + quote;
            string comandoFormatado =
            String.Format(@"schtasks /create /sc hourly /mo {3} /sd 03/01/2002 /tn  {0} /tr " + quote + " {2} -h 127.0.0.1 -p 5432 -U postgres -F c -b -v -f {1} SwitchDB " + quote + " ",
            NomeTarefa,
            PastaBkp,
            CaminhoDump,
            HoraBkp
            );
            ExecutarCMD(comandoFormatado);
        }
        public void AgendarTarefaAccess(string NomeTarefa, string PastaBkp, string CaminhoArquivo, string HoraBkp)
        {
            ExcluiTarefa(NomeTarefa);
            char quote = '"';
            string comandoFormatado =
            String.Format(@"schtasks /create /sc hourly /mo {3} /sd 03/01/2002 /tn  {0} /tr " + quote + "cmd /c  copy {2} {1}" + quote + " ",
            NomeTarefa,
            PastaBkp,
            CaminhoArquivo,
            HoraBkp
            );
            ExecutarCMD(comandoFormatado);
        }
        private static void ExecutarCMD(string comando)
        {
            System.Diagnostics.Process.Start("CMD.exe", @"/C " + comando).WaitForExit();
        }
        private void ExcluiTarefa(string NomeTarefa)
        {
            string excluirTarefa = String.Format(@"Schtasks /delete /f /TN {0}", NomeTarefa);
            ExecutarCMD(excluirTarefa);
        }

    }
}
