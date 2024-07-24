
#Link  

# Docker

![[Pasted image 20240724105455.png]]

_________________



## Installation

![[Pasted image 20240724104721.png]]

Installing Docker Engine on Arch Linux is a bit more involved than on other distributions, but it's still a relatively straightforward process. Here are the steps:



### Method 1

- 1. **Update your system**: 
```bash
	sudo pacman -Syyu
```


- 2. **Install the `docker` package**: 
```bash
	sudo pacman -S docker
```


- 3. **Start the Docker service**: 
```bash
	sudo systemctl start docker
```

- 4. **Enable the Docker service to start at boot**:
```bash
	sudo systemctl enable docker
```

- 5. Method 1 are running ? You've successfully installed Docker Engine on your Arch Linux system


To verify that Docker is working correctly, you can run a few commands:

1. **Check the Docker version**: 
```bash
	docker --version   // `For excample: Docker version 27.0.3, build 7d4bcd863a`
```



2. **Run a test container**:  
```bash
	docker run -it ubuntu /bin/bash
```
- (this will start a new Ubuntu container and open a bash shell inside it)


3. **List running containers**: 
```bash
	docker ps
```
- (this should show you the test container you just started)

4. **Stop the test container**: 
```bash
	docker stop <container_id> // `replace <container_id> with the ID of the test container`
```



If everything is working as expected, you should see the Docker version, be able to run a test container, and list/stop the container using the above commands.

Now that you have Docker Engine installed, you can start exploring the world of containerization!

#### Arch Linux
- When you're running Arch Linux with kernel version 6.10.0-arch1-2.


When it comes to pulling a Docker image, the `arch` image is not a valid option.
The `arch` image is not an official Docker image, and it's not designed to run as a container.

Instead, you can use the following Docker images, which are compatible with Arch Linux:

1. **`ubuntu`**: A popular choice for running a Linux container. You can pull the latest Ubuntu image using `docker pull ubuntu`.
2. **`debian`**: Another popular Linux distribution that can run as a container. You can pull the latest Debian image using `docker pull debian`.
3. **`alpine`**: A lightweight Linux distribution that's often used as a base image for other containers. You can pull the latest Alpine image using `docker pull alpine`.

If you want to run a container with a similar environment to your host system (Arch Linux), you can use the `archlinux` image from the Docker Hub. However, please note that this image is not officially supported by Docker, and it might not be up-to-date.

To pull the `archlinux` image, use the following command:


```bash
	docker pull archlinux/archlinux
```

Keep in mind that this image might not be optimized for running as a container, and you might encounter issues.

Some other useful Docker commands you might want to explore:

- List all available Docker images on your system:
```bash
	docker images
```

- List all running containers
```bash
	docker ps
```

- Run a new container from the specified image and open a bash shell inside it
```bash
	docker run -it <image_name> /bin/bash
```

- Stop a running container:
```bash
	docker stop <container_id>
```

- Remove a stopped container:
```bash
	docker rm <container_id>
```



Feel free to ask if you have any more questions or need help with Docker!



Some next steps you might want to consider:
#### Pull a Docker-Image: 

```bash
	docker pull <image-name> // `docker pull ubuntu`
```

. and
#### Run a Docker-Image

```bash
	docker run -it <image_name>  // `docker run -it ubuntu`
```
.
```bash
	docker run -it ubuntu /bin/bash
```
.
```bash
	docker run -it alpine /bin/bash
```
#### Create a Dockerfile
- To create a `Dockerfile` and build a custom image, follow these steps:

**Step 1: Create a new directory
```bash
	mkdir my-alpine-image
```
. and navigate into it
```bash
	cd my-alpine-image
```

**Step 2: Create a `Dockerfile` in the new directory**
```bash
	touch Dockerfile
```
.

**Step 3: Edit the `Dockerfile`**
- Open the `Dockerfile` in your favorite editor
```bash
	nano Dockerfile
```
.

- and add the following contents:
```dockerfile
	
# Use an official Alpine Linux image as a base
FROM alpine:latest

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
COPY . /app

# Install any necessary packages
RUN apk add --no-cache python

# Make port 80 available to the world outside this container
EXPOSE 80

# Define environment variable
ENV NAME=John

# Run `command` when the container launches
CMD ["python", "app.py"]
```
.
Let me explain what each line does:

- `FROM alpine:latest`: We use the latest Alpine Linux image as a base.
- `WORKDIR /app`: We set the working directory in the container to `/app`.
- `COPY . /app`: We copy the current directory contents into the container at `/app`.
- `RUN apk add --no-cache python`: We install Python using the `apk` package manager.
- `EXPOSE 80`: We make port 80 available to the world outside this container.
- `ENV NAME=John`: We define an environment variable `NAME` with value `John`.
- `CMD ["python", "app.py"]`: We set the default command to run when the container launches, which is `python app.py`.

**Step 4: Create a file `app.py` in the same directory**

```bash
	touch app.py
```

**Step 5: Edit `app.py`**
- Open `app.py` in your favorite editor and add some Python code, for example:

```python
	print("Hello, World!")
	print("My name is", NAME)
```
.

**Step 6: Build the custom image**
- Enable Experimental Features:

```bash
	export DOCKER_CLI_EXPERIMENTAL=enabled
```


**Step 7: login with Docker ID**
- login in with yout ID or E-Mail adress to push and pull images from Docker Hub
- if you dont have an docker id -  head over to https://hub.docker.com/ to create one
- you can log in with your Password or Personal Acces Token ( #PAT )
- using a limited-scope PAT grants better secruity and is required for organizations using SSO
- learn more at https://docs.docker.com/docker-id/ or https://app.docker.com/signup/
- Username: `db`
- Password: `docker`
- Method PAT: https://app.docker.com/settings/personal-access-tokens/create
	- Access token description `PAT`
	- Access permission `Read,Write,Delete`
	- Click on -> Generate


![[Pasted image 20240724141339.png]]
.

- to use the access token from your Docker CLI client:

```bash
	docker login registry-1.docker.io -u dockeratydh
```

.
- and copy the access token in to your login 

![[Pasted image 20240724143403.png]].
- At the password prompt, enter the personal access token.

```bash
	dckr_pat_      R9IqBU-KvvHPwFCxxxkiM
``` 
.
![[Pasted image 20240724142744.png]]

. and now your login succeded !

![[Pasted image 20240724143614.png]]
.

**Step 8: Build the custom image**

```bash
	docker run -it my-alpine-image
```
.
This command runs a new container from the `my-alpine-image` image and opens a terminal session inside the container.

That's it! You've created a custom Docker image using a `Dockerfile` and built it from scratch! 

#### Explore Docker Compose
- Install Docker Compose using:

```bash
	sudo pacman -S docker-compose` and learn how to define and run multi-container applications
	
```

#### Alpine Container
- usefull commands:

```bash
	docker run -it alpine /bin/bash
```

- `docker run`: This is the command to start a new Docker container.
- `-it`: This flag combination allows you to interact with the container as if you were sitting in front of it. `-i` allocates a pseudo-TTY, and `-t` enables terminal input/output.
- `alpine`: This is the name of the Docker image you want to use. In this case, it's the official Alpine Linux image.
- `/bin/bash`: This is the command to run inside the container. In this case, it starts a Bash shell.

When you run this command, Docker will create a new container from the Alpine image, and you'll be dropped into a Bash shell inside the container. From there, you can explore the container's file system, run commands, and more!