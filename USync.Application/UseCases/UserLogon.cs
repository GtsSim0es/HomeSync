using USync.Application.Interfaces;

namespace USync.Application.UseCases;

public class UserLogon(IUsersRepository userRepository)
{
    private readonly IUsersRepository _userRepository = userRepository;

    public async Task<bool> VerifyCredentialsOfUser(string login, string userPassword)
    {
        var user = await _userRepository.GetUserByLoginAsync(login);

        user.Validate();
        user.ValidatePassword(userPassword);
        if (!user.IsValid)
            return true;

        return false;
    }
}
