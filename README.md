# Develop Azure Compute Solutions - Understand the use of docker


## Understand the use of docker

### Install Docker on a Linux VM

- create a Linux VM
<img src="/pictures/linux.png" title="linux vm"  width="500">

- use putty to connect to the VM, and run the commands in *docker_commands.txt*

- in the end, you should see the version of Docker running on your VM
<img src="/pictures/linux2.png" title="linux vm"  width="300">

### Running an Nginx container on the Linux VM

- run the below command to spin up a simple container on the Linux VM
```
docker run --name mynginx -p 80:80 -d nginx
```

- add an inbound rule allowing HTTP
<img src="/pictures/nginx.png" title="nginx container"  width="500">

- you are now able to connect to the nginx server hosted on the VM
<img src="/pictures/nginx2.png" title="nginx container"  width="900">

### Docker on Visual Studio

- create *ASP.NET Core Web App* and add *Docker Support*. Choose *Linux* as targer OS

- start the application as a container

- on the **Docker Desktop**, see your container running
<img src="/pictures/container.png" title="container visual studio"  width="900">

### Publish an image to Docker Hub

- publish the app
<img src="/pictures/docker_hub.png" title="publish image to docker hub"  width="900">
<img src="/pictures/docker_hub2.png" title="publish image to docker hub"  width="900">

- the image is now available on your *Docker Hub*
<img src="/pictures/docker_hub3.png" title="publish image to docker hub"  width="900">

### Running the container on the linux VM

- on the VM run
```
docker pull dockeralexei/alexeidockerapp:latest
docker run --name alexeiappcontainer -d -p 80:80 dockeralexei/alexeidockerapp:latest
```

- you should now be able to see your app running on a container hoster on the linux VM
<img src="/pictures/docker_hub4.png" title="publish image to docker hub"  width="900">


## Azure Container Instances and Docker Compose

### Container Instances

- on the Azure Portal, create a container instance
<img src="/pictures/container_instance.png" title="container instance"  width="900">

- now the web app hosted on the container is available online
<img src="/pictures/container_instance2.png" title="container instance"  width="900">

### publish the project on the local machine

- create a new publish profile, choose folder
<img src="/pictures/publish_local.png" title="publish container to the local machine"  width="500">

- go to the publish folder and run commands below
```
docker build -t mydockerapp .
docker login
docker logout
docker tag mydockerapp dockeralexei/mydockerapp:v1
docker push dockeralexei/mydockerapp:v1
```

- in the end, you should see your image hosted on *dockerhub*
<img src="/pictures/publish_local2.png" title="publish container to dockerhub"  width="900">

### Publish changes to an image

- do some modification to your app

- on visual studio, do a publish on folder
<img src="/pictures/modif_image.png" title="publish changes to an image"  width="900">

- rebuild the image
```
docker build -t mydockerapp .
```

- remove the v1 version of the image, tag it again, and push it
```
docker image rm mydockerapp dockeralexei/mydockerapp:v1
docker tag mydockerapp:latest dockeralexei/mydockerapp:v1
docker push dockeralexei/mydockerapp:v1
```

- wait until the image is pushed

- on the *Azure Portal*, stop the container, and run it again

- finally, you should see the new versio of the app available on the web
<img src="/pictures/modif_image2.png" title="publish changes to an image"  width="900">

### Azure Container Registry

- on the azure portal, create a *container registry*
<img src="/pictures/container_registry.png" title="container registry"  width="500">

- on visual studio, create a new publish profile and publish
<img src="/pictures/container_registry2.png" title="container registry"  width="500">
<img src="/pictures/container_registry3.png" title="container registry"  width="500">
<img src="/pictures/container_registry4.png" title="container registry"  width="500">

- you should see your image created on the azure *Container Registry*
<img src="/pictures/container_registry5.png" title="container registry"  width="900">

- create a new *Container Instance* and use the image just pushed to the *Container Registry*
<img src="/pictures/container_registry6.png" title="container registry"  width="500">

- finally you should see the new version available on the web

### Mounting Volumes

- on ubuntu command prompt, run the below commands
```
docker volume create myvolume
docker volume ls
docker container run -dit --mount source=myvolume,target=/app ubuntu
docker ps
docker attach <ubuntucontainerid>
```

- inside the ubuntu container
```
cd /app
echo "this is a container" > sample.txt
exit
```

- back to ubuntu
```
docker container run -dit --mount source=myvolume,target=/app ubuntu
docker ps
docker attach <ubuntucontainerid>
```
You should see again the sample.txt previouly created.

### Creating a MySQL container

- on ubuntu command prompt, run the below commands
```
docker run --name=mysql-instance -p 3307:3306 --restart on-failure -d -e MYSQL_ROOT_PASSWORD=Azure123 mysql
docker ps -a
docker exec -it mysql-instance mysql -uroot -p
docker container rm e0
docker logs mysql-instance
```

- insert data into the sql database
```
CREATE DATABASE appdb;
USE appdb;
CREATE TABLE Course
(
   CourseID int,
   CourseName varchar(1000),
   Rating numeric(2,1)
);

INSERT INTO Course(CourseID,CourseName,Rating) VALUES
(1,'AZ-204 Developing Azure solutions',4.5),
(2,'AZ-303 Architecting Azure solutions',4.6),
(3,'DP-203 Azure Data Engineer',4.7);
```

- the app is now working and retrieving data from the SQL database hosted on the docker container
<img src="/pictures/docker_sql.png" title="SQL database hosted on the docker container"  width="900">

