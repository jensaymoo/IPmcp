using IPmcp.Database.Models;
using LinqToDB;
using LinqToDB.Data;

namespace IPmcp.Database;

public class AppDataConnection(DataOptions options) : DataConnection(options)
{
    public ITable<Entity> Entities => this.GetTable<Entity>();
    public ITable<Field> Fields => this.GetTable<Field>();
    public ITable<Rule> Rules => this.GetTable<Rule>();
    public ITable<EntityTypeRule> EntityTypeRules => this.GetTable<EntityTypeRule>();
}
