using Microsoft.EntityFrameworkCore;
using Api_Botinochki.Data;
using Api_Botinochki.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
namespace Api_Botinochki.Controllers;

public static class UserEndpoints
{
    public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/User").WithTags(nameof(User));

        group.MapGet("/", async (ObuvContext db) =>
        {
            return await db.Users.ToListAsync();
        })
        .WithName("GetAllUsers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<User>, NotFound>> (int userid, ObuvContext db) =>
        {
            return await db.Users.AsNoTracking()
                .FirstOrDefaultAsync(model => model.UserId == userid)
                is User model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetUserById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int userid, CreateUser user, ObuvContext db) =>
        {
            var affected = await db.Users
                .Where(model => model.UserId == userid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.UserRoleId, user.UserRoleId)
                    .SetProperty(m => m.Fio, user.Fio)
                    .SetProperty(m => m.Login, user.Login)
                    .SetProperty(m => m.Password, user.Password)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateUser")
        .WithOpenApi();

        group.MapPost("/", async (CreateUser createuser, ObuvContext db) =>
        {
            User user = new User
            {
                UserRoleId=createuser.UserRoleId,
                Fio=createuser.Fio,
                Login = createuser.Login,
                Password = createuser.Password
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/User/{user.UserId}",user);
        })
        .WithName("CreateUser")
        .WithOpenApi();
        group.MapPost("/Login", async Task<IResult> (LoginUser loginuser, ObuvContext db) =>
        {
            User? user = await db.Users
                .FirstOrDefaultAsync(x => x.Login == loginuser.Login && x.Password == loginuser.Password);

            if (user == null)
            {
                return TypedResults.NotFound("Такого пользователя не существует");
            }

            return TypedResults.Ok(user);
        })
        .WithName("LoginUser")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int userid, ObuvContext db) =>
        {
            var affected = await db.Users
                .Where(model => model.UserId == userid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteUser")
        .WithOpenApi();
    }
}
