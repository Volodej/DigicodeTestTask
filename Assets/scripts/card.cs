using UnityEngine;

public class card : MonoBehaviour {

    public UISprite card_sprite;

    public int card_depth {
        set { card_sprite.depth = value; }
    }

    public void setup_card() {
        var green = Random.Range(0.7f, 1);
        var other_colors = Random.Range(0, 0.4f);
        card_sprite.color = new Color(other_colors, green, other_colors);
    }    
}
