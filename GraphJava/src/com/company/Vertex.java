package com.company;

class Vertex {
    public char label;        // Метка (например, ‘A’)
    public boolean wasVisited;

    public Vertex(char lab) {
        label = lab;
        wasVisited = false;
    }
}
