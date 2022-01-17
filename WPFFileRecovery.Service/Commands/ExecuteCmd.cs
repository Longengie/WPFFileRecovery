using Medallion.Shell;
using WPFFileRecovery.Service.Commands.Interfaces;

namespace WPFFileRecovery.Service.Commands;

/// <summary>
/// Execute CMD
/// </summary>
public class ExecuteCmd : IExecuteCmd
{
    /// <summary>
    /// Run Cmd Without Terminal
    /// </summary>
    /// <param name="executable">executable</param>
    /// <param name="param">parameters</param>
    /// <returns>Is Success</returns>
    public bool RunCmdWithoutTerminal(string executable, params string[] param)
    {
        var cmd = Command.Run(executable, param).Result;
        return cmd.Success;
    }
    /// <summary>
    /// Run Cmd Without Terminal Async
    /// </summary>
    /// <param name="executable">executable</param>
    /// <param name="param">parameters</param>
    /// <returns>Is Success</returns>
    public async Task<bool> RunCmdWithoutTerminalAsync(string executable, params string[] param)
    {
        var cmd = await Command.Run(executable, param).Task;
        return cmd.Success;
    }
}
