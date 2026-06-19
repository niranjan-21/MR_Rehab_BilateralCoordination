# MR_Rehab_BilateralCoordination

## Overview

MR_Rehab_BilateralCoordination is a Mixed Reality rehabilitation application developed using **Unity**, **OpenXR**, and **Meta Quest 3** to support upper-limb motor recovery in cardiovascular patients, particularly stroke survivors.

The application focuses on improving **bilateral upper-limb coordination**, which is the synchronised use of both hands through an interactive balance-based rehabilitation exercise. By combining real-world surroundings with virtual therapeutic tasks, the system provides an engaging alternative to conventional repetitive rehabilitation exercises.

---

## Exercise Description

The Bilateral Coordination exercise presents the user with a virtual balance platform and a ball positioned at its center.

The platform orientation is controlled using the relative heights of the user's hands:

* Raising the right hand while lowering the left tilts the platform in one direction.
* Raising the left hand while lowering the right tilts the platform in the opposite direction.
* Keeping both hands at approximately the same height maintains a level platform.

As the platform tilts, gravity causes the ball to roll across its surface. The user must continuously adjust both hands in a coordinated manner to prevent the ball from falling off the platform.

---


## Technical Implementation

### Hardware

* Meta Quest 3
* Hand Tracking
* Mixed Reality Passthrough

### Software

* Unity Game Engine
* OpenXR
* Meta XR SDK

### Core Features

#### Biomechanical Input Mapping

The system continuously tracks the vertical position of both hands and calculates their relative height difference.

A configurable calibration offset allows adaptation to individual users and varying rehabilitation requirements.

#### Deadzone Filtering

Small involuntary hand tremors and sensor noise are filtered using a deadzone mechanism, preventing unintended platform movements and improving control stability.

#### Smooth Platform Dynamics

Platform rotation is smoothed using damped interpolation techniques to create realistic and stable movement, avoiding abrupt orientation changes.

#### Physics-Based Ball Interaction

A physics-driven ball responds naturally to platform tilt and gravitational forces, creating intuitive cause-and-effect feedback for the user.

#### Automatic Reset Mechanism

If the ball falls off the platform, the system automatically resets the exercise by:

* Returning the ball to its initial position
* Removing residual velocity
* Restoring a consistent starting state for the next attempt

---

## Key Features

* Mixed Reality rehabilitation environment
* Real-time hand tracking
* Physics-based gameplay
* Continuous bilateral motor training
* Reproducible exercise conditions
* Designed for upper-limb rehabilitation research

---
