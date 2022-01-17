using WPFFileRecovery.Data.Models;

namespace WPFFileRecovery.Service.Commands.Interfaces;

public interface IExecuteWinfrCommand
{
    public bool CheckWinfr();
    public Task<bool> RunWinfrAsync(WinfrCommandModel winfrCommand);
}
