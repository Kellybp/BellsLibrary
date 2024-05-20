using BellsLibrary.API.Services.Models;
using BellsLibrary.UI.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Linq;


namespace BellsLibrary.UI.Components.Pages.Books;

public partial class BooksPage
{
    [Inject]
    public required IBookService Service { get; set; }
    [Inject]
    public required ILoanService LoanService { get; set; }

    private IQueryable<BookEntity>? _books;
    private IQueryable<LoanEntity>? _loans;
    private IQueryable<BookEntity>? _featured;

    private IDialogReference? _dialog;

    protected override async Task OnInitializedAsync()
    {
        await LoadBooks();
    }

    private async Task LoadBooks()
    {
        _books = (await Service.GetAllBooksAsync()).AsQueryable();
        _loans = (await LoanService.GetAllLoansAsync()).AsQueryable();
        _featured = (await Service.GetAllBooksAsync()).AsQueryable();
        _featured = _featured.OrderBy(x => Guid.NewGuid()).Take(5); ;
    }

    private async Task OnAddNewBookClick()
    {
        var panelTitle = $"Add a book";
        var result = await ShowPanel(panelTitle, new BookEntity() { Title = "New Book" });;
        if (result.Cancelled)
        {
            return;
        }
        var entity = result.Data as BookEntity;
        ShowProgressToast(nameof(OnAddNewBookClick), "Book", entity!.Title);
        await Service.AddBookAsync(entity!);
        CloseProgressToast(nameof(OnAddNewBookClick));
        ShowSuccessToast("Book", entity!.Title);
        await LoadBooks();
    }

    private async Task OnEditBookClick(BookEntity book)
    {
        var panelTitle = $"Edit book";
        var result = await ShowPanel(panelTitle, book, false);
        if (result.Cancelled)
        {
            return;
        }
        var entity = result.Data as BookEntity;
        ShowProgressToast(nameof(OnEditBookClick), "Book", entity!.Title, Operation.Update);
        await Service.UpdateBookAsync(entity!);
        CloseProgressToast(nameof(OnEditBookClick));
        ShowSuccessToast("Book", entity!.Title, Operation.Update);
        await LoadBooks();
    }

    private async Task OnDeleteBookClick(BookEntity entity)
    {
        var title = "Delete book?";
        var message = $"Are you sure you want to delete book: <b>{entity.Title}</b>?";
        var result = await ShowConfirmationDialogAsync(title, message);
        if (result.Cancelled)
        {
            return;
        }
        try
        {
            ShowProgressToast(nameof(OnDeleteBookClick), "Book", entity!.Title, Operation.Delete);
            await Service.DeleteBookAsync(entity);
            CloseProgressToast(nameof(OnDeleteBookClick));
            ShowSuccessToast("Book", entity.Title, Operation.Delete);
            await LoadBooks();
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                ShowFailureToast("Book", entity.Title, Operation.Delete, "The book is in use and cannot be deleted.");
            }
            else
            {
                ShowFailureToast("Book", entity.Title, Operation.Delete, ex.Message);
            }
        }
    }

    private async Task<DialogResult> ShowPanel(string title, BookEntity book, bool isAdd = true)
    {
        var primaryActionText = isAdd ? "Add" : "Save changes";
        var dialogParameter = new DialogParameters<BookEntity>()
        {
            Content = book,
            Alignment = HorizontalAlignment.Right,
            Title = title,
            PrimaryAction = primaryActionText,
            Width = "500px",
            PreventDismissOnOverlayClick = false,
        };
        _dialog = await DialogService.ShowPanelAsync<BookUpsertPanel>(book, dialogParameter);
        return await _dialog.Result;
    }
}
