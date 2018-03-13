"use strict";
window.onload = function () 
{
    const canv = document.createElement("canvas");
    canv.id = "mc";
    canv.width = 1024;
    canv.height = 768;
    document.body.appendChild(canv);

    const ctx = canv.getContext("2d"); // 2d context
    let gs = false; // game started
    let fkp = false; // first key pressed (initialization states)
    const baseSpeed = 3; // snake base movement speed
    let speed = baseSpeed; // snake movement speed
    let leftIsHolding = false;
    let rightIsHolding = false;
    let upIsHolding = false;
    let downIsHolding = false;
    let xv = 0; // velocity (x)
    let yv = 0; // velocity (y)
    let px = ~~(canv.width) / 2; // player X position
    let py = ~~(canv.height) / 2; // player Y position
    const pw = 20; // player width size
    const ph = 20; // player height size
    const aw = 20; // apple width size
    const ah = 20; // apple height size
    const apples = []; // apples list
    const trail = []; // tail elements list (aka trail)
    let tail = 100; // tail size (1 for 10)
    const tailSafeZone = 20; // self eating protection for head zone (aka safeZone)
    //let cooldown = false; // is key in cooldown mode
    //const score = 0; // current score

    // game main loop
    function loop()
    {
        // logic
        ctx.fillStyle = "black";
        ctx.fillRect(0, 0, canv.width, canv.height);

        // force speed
        px += xv;
        py += yv;

        // teleports
        if (px > canv.width) 
        {
            px = 0;
        }

        if (px + pw < 0) 
        {
            px = canv.width;
        }

        if (py + ph < 0)
        {
            py = canv.height;
        }

        if (py > canv.height)
        {
            py = 0;
        }

        // paint the snake itself with the tail elements
        ctx.fillStyle = "lime";

        for (let i = 0; i < trail.length; i++)
        {
            ctx.fillStyle = trail[i].color || "lime";
            ctx.fillRect(trail[i].x, trail[i].y, pw, ph);
        }

        trail.push({ x: px, y: py, color: ctx.fillStyle });

        // limiter
        if (trail.length > tail)
        {
            trail.shift();
        }

        // eaten
        if (trail.length > tail)
        {
            trail.shift();
        }

        // self collisions
        if (trail.length >= tail && gs)
        {
            for (let i = trail.length - tailSafeZone; i >= 0; i--)
            {
                if
                (
                    px < (trail[i].x + pw)
                    && px + pw > trail[i].x
                    && py < (trail[i].y + ph)
                    && py + ph > trail[i].y
                )
                {
                    // got collision
                    tail = 10; // cut the tail
                    speed = baseSpeed; // cut the speed

                    for (var t = 0; t < trail.length; t++)
                    {
                        // highlight lossed area
                        trail[t].color = "red";

                        if (t >= trail.length - tail)
                        {
                            break;
                        }
                    }
                }
            }
        }

        // paint apples
        for (let a = 0; a < apples.length; a++)
        {
            ctx.fillStyle = apples[a].color;
            ctx.fillRect(apples[a].x, apples[a].y, aw, ah);
        }

        // check for snake head collisions with apples
        for (let a = 0; a < apples.length; a++)
        {
            if
            (
                px < (apples[a].x + pw)
                && px + pw > apples[a].x
                && py < (apples[a].y + ph)
                && py + ph > apples[a].y
            )
            {
                // got collision with apple
                apples.splice(a, 1); // remove this apple from the apples list
                tail += 10; // add tail length
                speed += 1; // add some speed
                spawnApple(); // spawn another apple(-s)
                break;
            }
        }
    }

    // apples spawner
    function spawnApple()
    {
        const newApple =
            {
                x: ~~(Math.random() * canv.width),
                y: ~~(Math.random() * canv.height),
                color: "red"
            };

        // forbid to spawn near the edges
        if
        (
            (newApple.x < aw || newApple.x > canv.width - aw)
            ||
            (newApple.y < ah || newApple.y > canv.height - ah)
        )
        {
            spawnApple();
            return;
        }

        // check for collisions with tail element, so no apple will be spawned in it
        for (let i = 0; i < tail.length; i++)
        {
            if
            (
                newApple.x < (trail[i].x + pw)
                && newApple.x + aw > trail[i].x
                && newApple.y < (trail[i].y + ph)
                && newApple.y + ah > trail[i].y
            )
            {
                // got collision
                spawnApple();
                return;
            }
        }

        apples.push(newApple);

        if (apples.length < 3 && ~~(Math.random() * 1000) > 700)
        {
            // 30% chance to spawn one more apple
            spawnApple();
        }
    }

    // random color generator (for debugging purpose or just 4fun)
    function rc()
    {
        return "#" + ((~~(Math.random() * 255)).toString(16)) + ((~~(Math.random() * 255)).toString(16)) + ((~~(Math.random() * 255)).toString(16));
    }

    // velocity changer (controls)
    function changeDirection(evt)
    {
        if (evt.keyCode === 37 && (yv !== 0 || !fkp)) // left arrow
        {
            xv = -speed;
            yv = downIsHolding ? speed : upIsHolding ? -speed : 0;
        }
        else if (evt.keyCode === 38 && (xv !== 0 || !fkp)) // top arrow
        {
            xv = leftIsHolding ? -speed : rightIsHolding ? speed : 0;
            yv = -speed;
        }
        else if (evt.keyCode === 39 && (yv !== 0 || !fkp)) // right arrow
        {
            xv = speed;
            yv = downIsHolding ? speed : upIsHolding ? -speed : 0;
        }
        else if (evt.keyCode === 40 && (xv !== 0 || !fkp)) // down arrow
        {
            xv = leftIsHolding ? -speed : rightIsHolding ? speed : 0;
            yv = speed;
        }

        if (!fkp)
            fkp = true;
    }

    function keyDownEventHandler(evt)
    {
        if (!fkp && [37, 38, 39, 40].indexOf(evt.keyCode) !== -1)
        {
            setTimeout(function () { gs = true; }, 1000);
            spawnApple();
        }

        //if (cooldown) 
        //{
        //    return false;
        //}

        if (evt.keyCode === 37) // left arrow
        {
            leftIsHolding = true;
        }
        else if (evt.keyCode === 38) // top arrow
        {
            upIsHolding = true;
        }
        else if (evt.keyCode === 39) // right arrow
        {
            rightIsHolding = true;
        }
        else if (evt.keyCode === 40) // down arrow
        {
            downIsHolding = true;
        }

        changeDirection(evt);

        //cooldown = true;
        //setTimeout(function () { cooldown = false; }, 100);

        return true;
    }

    function keyUpEventHandler(evt)
    {
        if (evt.keyCode === 37) // left arrow
        {
            leftIsHolding = false;
        }
        else if (evt.keyCode === 38) // top arrow
        {
            upIsHolding = false;
        }
        else if (evt.keyCode === 39) // right arrow
        {
            rightIsHolding = false;
        }
        else if (evt.keyCode === 40) // down arrow
        {
            downIsHolding = false;
        }
    }

    document.addEventListener("keydown", keyDownEventHandler);
    document.addEventListener("keyup", keyUpEventHandler);
    setInterval(loop, 1000 / 60); // 60 FPS
}

