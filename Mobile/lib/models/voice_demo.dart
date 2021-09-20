class VoiceDemo {
  int id;
  String path;

  VoiceDemo({
    required this.id,
    required this.path,
  });

  factory VoiceDemo.fromJson(Map<String, dynamic> json) {
    return VoiceDemo(
      id: json['id'],
      path: json['path'],
    );
  }
}
