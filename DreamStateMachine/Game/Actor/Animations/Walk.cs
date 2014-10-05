﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using DreamStateMachine.Behaviors;

namespace DreamStateMachine.Actions
{
    class Walk:Animation
    {
        AnimationInfo animationInfo;
        Actor owner;
        Vector2 walkDirection;
        double dotProduct;

        public Walk(ActionList ownerList, Actor owner)
        {
            this.ownerList = ownerList;
            this.owner = owner;
            if (owner.activeWeapon != null)
            {
                animationInfo = owner.animations[owner.activeWeapon.animations["walk"]];
            }
            else
            {
                if (owner.animations.ContainsKey("walk"))
                    animationInfo = owner.animations["walk"];
                else
                    animationInfo = new AnimationInfo("default_walk", 10, 12, 0, 0);
                duration = (float)animationInfo.frames / animationInfo.fps;
            }
        }

        //dummy constructor
        public Walk()
        {
        }

        override public void onStart()
        {
            elapsed = 0;
        }

        override public void onEnd()
        {
            if (owner.isWalking)
                elapsed = 0;
            else
                ownerList.remove(this);

            owner.setAnimationFrame(0, 0);
            

        }

        override public void update(float dt)
        {
            walkDirection.X = owner.velocity.X;
            walkDirection.Y = owner.velocity.Y;
            walkDirection.Normalize();
            dotProduct = Vector2.Dot(walkDirection, owner.sightVector);
            if (owner.isWalking && dotProduct > .5)
            {
                elapsed += dt;
                currentFrame = (int)(elapsed * animationInfo.fps);
                owner.setAnimationFrame(currentFrame, 0);
            }
            else if (owner.isWalking && dotProduct < -.5)
            {
                elapsed -= dt;
                if(elapsed <= 0)
                {
                    elapsed = (duration - .0001f);
                }
                currentFrame = (int)(elapsed * animationInfo.fps);
                owner.setAnimationFrame(currentFrame, 0);
            }
            else
            {
                this.onEnd();
            }

        }
    }
}
