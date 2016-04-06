Machine Learning Agent for Unity
=============

# This is under construction 
![screenshot](https://cloud.githubusercontent.com/assets/1708549/14311902/c6ce61ec-fc24-11e5-8018-5e3aaf98b6d3.png)

## Requirements:
- python 2.7

## Install
### Ubuntu 
Install Unity (experimental-build version):

```
wget http://download.unity3d.com/download_unity/unity-editor-installer-5.1.0f3+2015082501.sh
sudo sh unity-editor-installer-5.1.0f3+2015082501.sh

# run
./unity-editor-5.1.0f3/Editor/Unity

# if background is pink, install:
sudo apt-get install lib32stdc++6 -y
```

install python modules
```
pip install chainer
pip install ws4py
pip install cherrypy
pip install msgpack-python
```

### Mac
Install Unity. I reccomend using Unity 5.1.0 (for linux experimental-build version)

install python modules
```
pip install chainer
pip install ws4py
pip install cherrypy
pip install msgpack-python
```

### Windows

not supported

## Quick Start
download data:

```
./fetch.sh
```

Next, run python module as a server.

```
cd python-agent
python server.py
```

Open unity-sample-environment in Unity and load Scenes/sample

![screenshot from 2016-04-06 18 08 31](https://cloud.githubusercontent.com/assets/1708549/14311462/990e607e-fc22-11e5-84cf-26c049482afc.png)

Press Start Buttn. In first time, this will take a few minuts time.

![screenshot from 2016-04-06 18 09 36](https://cloud.githubusercontent.com/assets/1708549/14311518/c309f8f2-fc22-11e5-937c-abd0d227d307.png)


## System Architecture


Client: Unity

Server: python module

[TODO:image]




## Algorithm Reference 

+ [DQN-chainer](https://github.com/ugo-nama-kun/DQN-chainer)
 + Copyright (c) 2015 Naoto Yoshida
 + The MIT License (MIT)


## Module Reference

+ MessagePack for Unity 
 + Copyright (C) 2011-2012 Kazuki Oikawa, Kazunari Kida
 + Apache License, Version 2.0
 + Assets/Packages/msgpack-unity 

+ websocket-sharp
 + Copyright (c) 2010-2016 sta.blockhead
 + The MIT License (MIT)
 + Assets/Packages/websocket-sharp
