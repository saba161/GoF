namespace Adapter;

public interface ICashMachine
{
    /// <summary>
    /// Unique cash register number.
    /// </summary>
    string Number { get; }

    /// <summary>
    /// Collection of products in the current ticket.
    /// </summary>
    IReadOnlyList<Product> Products { get; }

    /// <summary>
    /// Collect check and print it out.
    /// </summary>
    /// <remarks>
    /// Printing a check causes it to be saved
    /// and the collection of goods of the current check is cleared.
    /// </remarks>
    /// <returns>Text check</returns>
    string PrintCheck();

    /// <summary>
    /// Add a product to the collection of products of the current receipt.
    /// </summary>
    /// <param name="product">Product added to check.</param>
    void AddProduct(Product product);

    /// <summary>
    /// Save check.
    /// </summary>
    /// <remarks>
    /// Saving a receipt causes the collection of goods of the current receipt to be cleared.
    /// </remarks>
    /// <param name="checkText"></param>
    void Save(string checkText);
}