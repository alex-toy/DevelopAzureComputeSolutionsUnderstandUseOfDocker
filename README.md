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

