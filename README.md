Set up instructions
- change Data Source to your server name and user credentials your user name for  connection string in web.config and app.config
``` 
    <add name="CandidateConnectionString" connectionString="Data Source=YOUR SERVER;Initial Catalog=CandidateAppDb;Persist Security Info = True;User ID=YOUR USERNAME;Password=YOUR PASSWORD" providerName="System.Data.SqlClient" />
```

- run application one time to seed db
- after running, comment out the db seed in candidateDbContext file 
```
  public CandidateDbContext() : base("CandidateConnectionString")
        {
        // COMMENT OUT THIS LINE BELOW
            Database.SetInitializer<CandidateDbContext>(new UniDBInitializer<CandidateDbContext>());

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
```
- Run application
