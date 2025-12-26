Stretch & Squash Rig (Unity – IAnimationJob)

A procedural Stretch & Squash system for Unity built using a low-level IAnimationJob and Unity’s Animation Rigging / Playables pipeline.

This tool applies stretch and squash directly in the animation stream, layered non-destructively on top of IK and existing animations.



https://github.com/user-attachments/assets/3d814ffe-8e39-491f-9363-ac0fb4bcfff3



✨ Features

Procedural stretch & squash evaluated at runtime

Built with IWeightedAnimationJob (no Animator state hacks)

Works alongside Two Bone IK and authored animations

Volume preservation via squash math

Axis-selective deformation (X / Y / Z)

Min / Max stretch limits for stability

Global controller for tuning multiple rigs

Animator-friendly & non-destructive

Supports cartoony → realistic styles

_______________________________________________________________________________________________________________________

🧠 Technical Overview

The system works by measuring the live distance between the upper joint and the IK target, comparing it against a stored rest length, and computing a stretch ratio:

Stretch ratio = currentDistance / restLength

Ratio is blended using an intensity factor

Squash is applied using inverse scaling to preserve volume

Deformation is split between upper & lower bones using a distribution parameter

All values are evaluated inside ProcessAnimation() using AnimationStream, making it frame-safe and performant.

_______________________________________________________________________________________________________________________

🧩 Architecture

StretchJob
Implements IWeightedAnimationJob
Handles all stretch/squash math and bone scaling

StretchData
Holds rig references and parameters
Uses [SyncSceneToStream] for live editor updates

StretchBinder
Binds scene data to animation stream via FloatProperty

StretchConstraint
Custom RigConstraint wrapper
Includes rest-length calculation and IK reset utilities

_______________________________________________________________________________________________________________________

🛠 Requirements

Unity 6000.0.43f1

URP 3D Project

Unity Packages:

Animation Rigging 1.3.1

TextMeshPro

⚠️ If you see pink materials or a blank scene, make sure URP is properly set up.

_______________________________________________________________________________________________________________________

📦 Installation

Create a URP 3D Project

Install required packages

Import
StretchRig_SaurabhKundalwal.unitypackage

Open the demo scene:
Demo_StretchRig_Scene

_______________________________________________________________________________________________________________________

🧪 Usage

Set up standard Two Bone IK first

Assign Upper, Lower, and IK Tip transforms

Add StretchConstraint to a new Rig layer

Adjust parameters:

Intensity

Min / Max Stretch

Squash Amount

Stretch Distribution

Axis selection

Optionally control multiple rigs via the Global Stretch Controller

_______________________________________________________________________________________________________________________

🎯 Use Cases

Character animation polish

Cartoony or exaggerated motion

Procedural animation systems

Gameplay-driven deformation

Technical Artist tooling

_______________________________________________________________________________________________________________________

📈 Performance Notes

Runs fully inside the animation stream

No per-frame allocations

No Animator graph complexity

Safe for runtime and editor usage

_______________________________________________________________________________________________________________________

📄 Demo & Docs

A full setup guide and screenshots are included in:
Stretch & Squash Tool Docs (PDF)


👤 Author :-
Saurabh Kundalwal
