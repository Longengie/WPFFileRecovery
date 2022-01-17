using WPFFileRecovery.Data.Models;
using WPFFileRecovery.Service.Commands.Interfaces;
using WPFFileRecovery.Service.Helpers;

namespace WPFFileRecovery.Service.Commands;

public class ExecuteWinfrCommand : IExecuteWinfrCommand
{
    private readonly IExecuteCmd _executeCmd;
    public ExecuteWinfrCommand(IExecuteCmd executeCmd)
    {
        _executeCmd = executeCmd;
    }

    public bool CheckWinfr() => _executeCmd.RunCmdWithoutTerminal("winfr", "-?");
    public async Task<bool> RunWinfrAsync(WinfrCommandModel winfrCommand)
    {
        string[] param = WinfrCommandHelper.GenerateWinfrCommand(winfrCommand);
        var exec = await _executeCmd.RunCmdWithoutTerminalAsync("winfr", param);
        return exec;
    }
}
