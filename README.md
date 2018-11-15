# Docker_ASP_NET_CORE_SqlServer
# Some concept
-----------------------------

    Dockerfile: file cấu hình project để build image. 
      Trong Dockerfile có 1 số lệnh cần chú ý: ( 1 FROM giống như 1 function nó sẽ chạy tất cá các lệnh từ trên xuống dưới trong FROM đó. )
        1) FROM: Lấy 1 image để làm nền tảng,các image sẽ được tìm và tự động tải về trên docker hub nếu tên image phù hợp.
        2) WORKDIR: Di chuyển thư mục
        3) RUN: Chạy lệnh Bash shell được chỉ định VD: dotnet restore "./QL_Sach.csproj"
        4) ENV: Biến môi trường, cái này khá quan trọng vì khi run project trong môi trường Linux mặc định không có biến này. Nếu không thiết lập sẽ bị văng Error: ENVIROMENT DEVELOPER. 
        5) COPY: Lệnh copy
        6) ENTRYPOINT: Sử dụng để run 1 tập lệnh bash shell được viết trong file name.sh
    Build Dockerfile sẽ tạo ra được Docker Image ( chứa tất cả cấu hình hệ thống, bao gồm cả source code của bạn. )
    Run Docker Image sẽ tạo ra Docker Container ( chạy cái project của bạn trên nền tảng của image. Giống như việc bạn đã code, build, debug mọi thứ trên Visual Studio nhưng chưa có bấm F5 run code vậy á. Khi Run Image giống như việc bạn bấm F5 Run project trên Visual Studio.)
    Docker-compose: thực hiện run nhiều image tạo ra nhiều container kết nối với nhau.
## How to create it.
#Step 1: Create Project ASP.NET CORE
------------------------------------
  Bashshell: mkdir Project_name && cd Project_name
  
#Step 2: Add EF_Core
--------------------------------------------
  Bashshell: dotnet add package Microsoft.EntityFrameworkCore.SqlServer

#Step 3: Create file <Table_Name>.cs in Folder Models
--------------------------------------------
  After that, create file <Database_name>_Context.cs in there. 
  ==> Use EF code first.
 
#Step 4: In Startup.cs
--------------------------------------
   var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
   
   var password = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "ThisIsPass1@";
   
   //var connString_1 = $"Data Source={hostname};Initial Catalog=Database_name;User ID=sa;Password={password};";
  
   var connString_2 = $"Server=db;Initial Catalog=Database_name;User ID=sa;Password={password};";
   
   services.AddDbContext<Database_name_Context>(options => options.UseSqlServer(connString));
   
 #Note: connString_1 use for run Docker Image(this Project) single with Docker Image (SQL_Server).
 
  connString_2 use for run Docker Compose -- Run dual Docker image ( this project ) and Docker image (SQL_Server)
        
  db in connString_2 can setting name in docker-compose.yml
        
#Step 5: Use docker tool in Visual studio add Dockerfile - ASP.NET CORE in Linux.
-----------------------------------------------------------
 # Note: Remember add ENV ASPNETCORE_ENVIRONMENT development below FROM base AS final
 
        @@Example: 
            FROM base AS final
            ENV ASPNETCORE_ENVIRONMENT development
  
  After that build image from this dockerfile
  
##Bonus: In here, you have 1 image of your project and you can run this as follows: 

    // using connString_1. 
    
    // Bash-shell: docker pull microsoft/mssql-server-linux
    
    // Bash-shell: docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=ThisIsPass1@' -p 1433:1433 --name sqlserver -d microsoft/mssql-server-linux
    
    // Bash-shell: docker run -it --rm -p 5000:80 --link sqlserver -e SQLSERVER_HOST=sqlserver <name_image_of_yourproject>
    
   =====================================
   Or You can write dockerfile manually without using Docker tool. 
   
#Step 6: Create Docker-compose.yml
----------------------------------------
  ## This file like this:
      version: "3"
      services:
        web: //Tên service
            image: "deftnt/asp_net_core_sql_server" //Tên image sẽ chạy
            ports: // Thiết lập cổng
                - "8000:80"
            restart: always // Options tự đổng restart mỗi lần call
            depends_on: // Quan trọng -- kết nối giữa 2 Image. Thằng này muốn chạy thì cần phải chạy thằng services db trước.
                - db
        db:
            image: "microsoft/mssql-server-linux"
            hostname: 'sqlserver'
            environment: // 
                SA_PASSWORD: "ThisIsPass1@"
                ACCEPT_EULA: "Y"
            restart: always
 ====================================================================================================================
#How to run

BashShell: docker-compose -f "docker-compose.yml" up -d --build

=============================
http://0.0.0.0:8000/Book/ViewBook
