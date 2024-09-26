using System;
using BlogAPIDotnet.Models;

namespace BlogAPIDotnet.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
