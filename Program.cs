var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<Category> categories = new List<Category>();

app.MapGet("/", () => "API Running");

// Read => GET: /api/categories
app.MapGet("/api/categories", () =>
{
    return Results.Ok(categories);
});

// Create => Create A Category => POST: /api/categories
app.MapPost("/api/categories", () =>
{
    var newCategory = new Category
    {
        CategoryId = Guid.Parse("1d7cc09b-16d4-47dc-8666-0832fd59e766"),
        Name = "SmartPhone",
        Description = "This Device is ultra modern technology which could make your lifestyle use friendly and lively.",
        CreatedAt = DateTime.UtcNow,
    };
    categories.Add(newCategory);
    return Results.Created($"/api/categories/{newCategory.CategoryId}", newCategory);
});

// Delete => Delete a Category => Delete: /api/categories
app.MapDelete("/api/categories", () =>
{
    var findCategory = categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("1d7cc09b-16d4-47dc-8666-0832fd59e766"));
    if(findCategory == null)
    {
        return Results.NotFound("Not Exist!");
    }
    categories.Remove(findCategory);
    return Results.NoContent();
});

// Update => Update a Category => PUT: /api/categories
app.MapPut("/api/categories", () =>
{
    var findCategory = categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("1d7cc09b-16d4-47dc-8666-0832fd59e766"));
    if(findCategory == null)
    {
        return Results.NotFound("Not Exist!");
    }
    findCategory.Name = "Mobile Phone";
    findCategory.Description = "DSKJF KDJSDLSFJDLKS DSKF DSKFDLKJS DSFJ";
    return Results.NoContent();
});

app.Run();

public record Category
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
};

// CRUD



