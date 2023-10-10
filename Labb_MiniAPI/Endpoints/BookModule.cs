using AutoMapper;
using FluentValidation;
using Labb_MiniAPI.Service;
using Microsoft.AspNetCore.Mvc;
using ModelsLib.Models;
using ModelsLib.Models.MVC_Tools;
using System.Net;

namespace Labb_MiniAPI.Endpoints
{
    public static class BookModule
    {
        public static void AddBookEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/book/create",
                async (IValidator<BookDTO> validator, IMapper mapper, IBookRepo repo, [FromBody] BookDTO book_dto) =>
                {
                    try
                    {
                        var response = new ApiResponse() { StatusCode = HttpStatusCode.NotFound, IsSuccess = false };
                        var validResult = await validator.ValidateAsync(book_dto);
                        if (validResult.IsValid)
                        {
                            var book = mapper.Map<Book>(book_dto);
                            var toAdd = await repo.CreateBook(book);
                            var result = mapper.Map<BookDTO>(toAdd);
                            response.Result = result;
                            response.IsSuccess = true;
                            response.StatusCode = HttpStatusCode.Created;
                            return Results.Ok(response);
                        }
                        return Results.BadRequest(response);
                    }
                    catch (Exception e)
                    {
                        return Results.BadRequest(e);
                    }
                }).WithName("CreateBook").Accepts<BookDTO>("application/json").Produces<ApiResponse>(201).Produces(400);

            app.MapGet("/api/book/all", async (IBookRepo repo) =>
            {
                try
                {
                    var result = await repo.GetAllBooks();
                    if (result != null)
                    {
                        var response = new ApiResponse
                        {
                            Result = result,
                            IsSuccess = true,
                            StatusCode = HttpStatusCode.OK,
                        };
                        return Results.Ok(response);
                    }
                    return Results.NoContent();
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e);
                }
            }).WithName("AllBooks").Produces(200);

            app.MapGet("/api/book/{id:int}",
                async (IBookRepo repo, int id) =>
                {
                    try
                    {
                        var response = new ApiResponse() { StatusCode = HttpStatusCode.NotFound, IsSuccess = false };
                        var result = await repo.GetBookById(id);
                        if (result != null)
                        {
                            response.Result = result;
                            response.IsSuccess = true;
                            response.StatusCode = HttpStatusCode.OK;
                            return Results.Ok(response);
                        }
                        response.ErrorMessages.Add("Invalid ID");
                        return Results.NotFound(response);
                    }
                    catch (Exception e)
                    {
                        return Results.BadRequest(e);
                        throw;
                    }
                }).WithName("GetBookByID").Produces<ApiResponse>(200).Produces(400);

            app.MapPut("/api/book/update/{id:int}", 
                async (IValidator<BookDTO> validator, IBookRepo repo, IMapper mapper,int id, [FromBody] BookDTO book_dto) =>
            {
                try
                {
                    var response = new ApiResponse() { StatusCode = HttpStatusCode.NotFound, IsSuccess = false };
                    var validResult = await validator.ValidateAsync(book_dto);

                    if (validResult.IsValid)
                    {
                        var book = mapper.Map<Book>(book_dto);
                        var toAdd = await repo.UpdateBook(book, id);
                        var result = mapper.Map<BookDTO>(toAdd);
                        response.Result = result;
                        response.IsSuccess = true;
                        response.StatusCode = HttpStatusCode.OK;
                        return Results.Ok(response);

                    }
                    response.ErrorMessages.Add(validResult.Errors.FirstOrDefault().ToString());
                    return Results.BadRequest(response);
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e);
                }
            }).WithName("UpdateBook").Accepts<BookDTO>("application/json").Produces<ApiResponse>(200).Produces(400);

            app.MapDelete("/api/book/delete/{id:int}", async (IBookRepo repo, int id) =>
            {
                try
                {
                    var response = new ApiResponse() { StatusCode = HttpStatusCode.NotFound, IsSuccess = false };
                    var result = await repo.DeleteBook(id);
                    if (result != null)
                    {
                        response.StatusCode = HttpStatusCode.OK;
                        response.Result = result;
                        response.IsSuccess = true;
                        return Results.Ok(response);
                    }
                    response.ErrorMessages.Add("Invalid ID");
                    return Results.NotFound(response);
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e);
                }
            }).WithName("DeleteBook").Produces<ApiResponse>(200).Produces(400);
            app.MapGet("/api/book/search/{search}",
                async (IBookRepo repo, IMapper mapper, string search) =>
                {
                    try
                    {
                        var response = new ApiResponse() { StatusCode = HttpStatusCode.NotFound, IsSuccess = false };
                        var result = await repo.Search(search);
                        if (result != null)
                        {
                           // var found = mapper.Map<IEnumerable<BookDTO>>(result);
                            response.StatusCode = HttpStatusCode.OK;
                            response.Result = result;
                            response.IsSuccess = true;
                            return Results.Ok(response);
                        }
                        return Results.NotFound(response);
                    }
                    catch (Exception e)
                    {
                        return Results.BadRequest(e);
                    }
                }).WithName("BookSearch").Produces<ApiResponse>(200).Produces(400);
        }
    }
}
