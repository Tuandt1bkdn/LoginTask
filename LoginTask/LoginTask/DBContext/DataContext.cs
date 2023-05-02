namespace LoginTask.DBContext;

using Dapper;
using LoginTask.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;


public class DataContext:DbContext
    {
    public DataContext(DbContextOptions<DataContext> options) : base(options) 
    { 
    
    }
    public DbSet<UserInfoModel> UserInfos { get; set; }
    
    }
