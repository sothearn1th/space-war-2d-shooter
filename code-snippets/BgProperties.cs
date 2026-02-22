//....
/* OTHER IMPLEMENTED CODES */

    [SerializeField] float movSpd;
    float singleTextureWidth; /// The seam killer/provides seamless reset.


/* OTHER IMPLEMENTED CODES */
//....
/* OTHER IMPLEMENTED CODES */

    // Cache the width (in world units) of ONE texture tile so we know when the object has moved
    // far enough to loop/reset for an endless scrolling effect.
    private void setUp()
    {
        // Get the Sprite currently assigned to this object's SpriteRenderer.
        // NOTE: If the SpriteRenderer or sprite is missing, this will throw a NullReferenceException.
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;

        // Convert texture pixel width into world units:
        // worldWidth = pixelWidth / pixelsPerUnit
        // Example: 1024px texture at 100 PPU => 10.24 world units wide.
        singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    private void scroll()
    {
        // How far to move this frame (negative = move left).
        // Using Time.deltaTime makes movement frame-rate independent.
        float delta = -movSpd * Time.deltaTime;

        // Move left along X in world space.
        transform.position += new Vector3(delta, 0f, 0f);
    }

    ///Called in update()
    private void checkReset()
    {
        // If the object has moved more than one tile width away from the origin on X,
        // snap it back to X = 0 to create a looping illusion.
        //
        // Math.Abs(...) lets this work whether x is negative or positive.
        // (Math.Abs(x) - width) > 0  is the same as  Math.Abs(x) > width
        if ((Math.Abs(transform.position.x) - singleTextureWidth) > 0)
        {
            // Reset only X; keep the current Y and Z.
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }
/* OTHER IMPLEMENTED CODES */
//....