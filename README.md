Machine Learning Agent for Unity
=============

# This is under construction 

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

Open unity-sample-environment in Unity and load unity-sample-environment/Scenes/sample

[TODO:image]

Next, run python module as a server.

```
cd python-agent
python server.py
```



## System Architecture


Client: Unity

Server: python module

[TODO:image]




## Algorithm Reference 

+ [DQN-chainer](https://github.com/ugo-nama-kun/DQN-chainer)
 + Copyright (c) 2015 Naoto Yoshida
 + The MIT License (MIT)


## License & Copyright

+ MessagePack for Unity 
 + Copyright (C) 2011-2012 Kazuki Oikawa, Kazunari Kida
 + Apache License, Version 2.0
 + Assets/Packages/msgpack-unity 

+ websocket-sharp
 + Copyright (c) 2010-2016 sta.blockhead
 + The MIT License (MIT)
 + Assets/Packages/websocket-sharp
