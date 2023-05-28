# Develop Azure Compute Solutions - Understand the use of docker


## Install Docker on a Linux VM

- create a Linux VM
<img src="/pictures/linux.png" title="linux vm"  width="500">

- use putty to connect to the VM, and run the commands in *docker_commands.txt*

- in the end, you should see the version of Docker running on your VM
<img src="/pictures/linux2.png" title="linux vm"  width="300">


## Running an Nginx container on the Linux VM

- run the below command to spin up a simple container on the Linux VM
```
docker run --name mynginx -p 80:80 -d nginx
```

- add an inbound rule allowing HTTP
<img src="/pictures/nginx.png" title="nginx container"  width="500">
```

- you are now able to connect to the nginx server hosted on the VM
<img src="/pictures/nginx2.png" title="nginx container"  width="500">


## Working with the container


## Creating, publishing and creating a container from the image

- run the below command
```
docker build -t myapp .
docker login
docker logout
docker tag myapp shakinstev/myapp:v1
docker push shakinstev/myapp:v1
```





https://github.com/cloudxeus/Azure-Dev/tree/main/AZ-204%20-%20Develop%20Azure%20Compute%20Solutions%20-%20Docker