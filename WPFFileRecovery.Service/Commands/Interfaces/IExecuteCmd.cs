namespace WPFFileRecovery.Service.Commands.Interfaces;

public interface IExecuteCmd
{
    /// <summary>
    /// Run Cmd Without Terminal
    /// </summary>
    /// <param name="executable">executable</param>
    /// <param name="param">parameters</param>
    /// <returns>Is Success</returns>
    public bool RunCmdWithoutTerminal(string executable, params string[] param);
    /// <summary>
    /// Run Cmd Without Terminal Async
    /// </summary>
    /// <param name="executable">executable</param>
    /// <param name="param">parameters</param>
    /// <returns>Is Success</returns>
    public Task<bool> RunCmdWithoutTerminalAsync(string executable, params string[] param);
}
