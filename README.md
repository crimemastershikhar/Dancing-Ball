# 🎵 **Dancing Ball** 🎮

## 🕹️ **Game Overview**

**Dancing Ball** is a dynamic 3D arcade game developed in Unity.  
Navigate a perpetually moving ball through automatic generated platforms, collecting gems and avoiding falling platforms.  
As you progress, the game's speed and difficulty escalate, challenging your timing and precision.

## 🎯 **Objective**

- **Keep the ball on the platform without falling**
- **Collect gems to increase your score**
- **Survive as long as possible to achieve high scores**

## ✨ **Key Features**

- **Collectibles** – Gems with captivating sound and particle effects
- **Dynamic Difficulty** – The game's pace increases over time, intensifying the challenge
- **Immersive Audio** – A rhythmic soundtrack that complements the gameplay

## ♻️ **Object Pooling Design Pattern**

To optimize performance and ensure smooth gameplay, **Dancing Ball** implements the **Object Pooling** design pattern.

This approach involves **reusing inactive/fallen platform ** instead of creating and destroying them repeatedly.  
By recycling these objects:
- The game minimizes memory allocation
- Reduces garbage collection overhead
- Leads to enhanced performance, especially on mobile or lower-end devices

## 🛠️ **Controls**
As this game was made for mobile devices primarily, the main controls are only the touch input. Based on the previous direction ball was moving, it moves left and right

## 🚀 **GamePlaye Video**
🔗 https://video.wixstatic.com/video/a2f27d_44676aec469541b8a4da7f07421c366f/720p/mp4/file.mp4
